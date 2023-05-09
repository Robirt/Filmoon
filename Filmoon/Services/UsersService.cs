using Filmoon.Models;
using Filmoon.Requests;
using Filmoon.Responses;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Filmoon.Services;

public class UsersService
{
    public UsersService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public JwtBearerModel JwtBearer { get; private set; } = new();

    public event EventHandler<SignInResponse>? SignedIn;

    public event EventHandler<ActionResponse>? SignedOut;

    public async Task<SignInResponse?> SignInAsync(SignInRequest request)
    {
        var signInResponse = await (await HttpClient.PostAsJsonAsync("Users/SignIn", request)).Content.ReadFromJsonAsync<SignInResponse>();

        if (signInResponse is null) return new SignInResponse(false, "Empty response.");

        if (signInResponse.Succeeded)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", signInResponse.Token);

            ConvertJwtBearerToken(signInResponse.Token);

            OnSignedIn(signInResponse);
        }

        return signInResponse;
    }

    public void SignOutAsync(ActionResponse actionResponse)
    {
        HttpClient.DefaultRequestHeaders.Remove("Authorization");

        JwtBearer = new JwtBearerModel();

        SignedOut?.Invoke(this, actionResponse);
    }

    public async Task<ActionResponse?> SignUpAsync(SignUpRequest request)
    {
        return await (await HttpClient.PostAsJsonAsync("Customers", request)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public void OnSignedIn(SignInResponse signInResponse)
    {
        SignedIn?.Invoke(this, signInResponse);
    }

    public void OnSignedOut(SignInResponse signInResponse)
    {
        SignedOut?.Invoke(this, signInResponse);
    }

    private void ConvertJwtBearerToken(string jwtBearer)
    {
        var jwtSecurityToken = new JwtSecurityTokenHandler().ReadToken(jwtBearer) as JwtSecurityToken;

        if (jwtSecurityToken is null) return;

        JwtBearer = new JwtBearerModel(Convert.ToInt32(jwtSecurityToken.Claims.First(c => c.Type == "nameid").Value), jwtSecurityToken.Claims.First(c => c.Type == "unique_name").Value, jwtSecurityToken.Claims.First(c => c.Type == "role").Value);
    }
}
