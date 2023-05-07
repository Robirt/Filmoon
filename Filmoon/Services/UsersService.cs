using Filmoon.Entities;
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
    public UsersService(IHttpClientFactory httpClientFactory)
    {
        HttpClient = httpClientFactory.CreateClient("HttpClient");
    }

    private HttpClient HttpClient { get; }

    public JwtBearerModel JwtBearer { get; private set; } = new();

    public event EventHandler<SignInResponse>? SignIn;

    public event EventHandler<ActionResponse>? SignOut;

    public void OnSignIn(SignInResponse signInResponse)
    {
        SignIn?.Invoke(this, signInResponse);
    }

    public async Task<SignInResponse?> SignInAsync(SignInRequest request)
    {
        var signInResponse = await (await HttpClient.PostAsJsonAsync("Users/SignIn", request)).Content.ReadFromJsonAsync<SignInResponse>();

        if (signInResponse is null) return new SignInResponse(false, "Empty response.");

        if (signInResponse.Succeeded)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", signInResponse.Token);

            ConvertJwtBearerToken(signInResponse.Token);

            OnSignIn(signInResponse);
        }

        return signInResponse;
    }

    public async Task<ActionResponse> SignUpAsync(SignUpRequest request)
    {
        var response = await HttpClient.PostAsJsonAsync("/Users/SignUp", request);
        return await response.Content.ReadFromJsonAsync<ActionResponse>();
    }

    public void SignOutAsync(ActionResponse actionResponse)
    {
        HttpClient.DefaultRequestHeaders.Remove("Authorization");

        JwtBearer = new JwtBearerModel();

        SignOut?.Invoke(this, actionResponse);
    }

    private void ConvertJwtBearerToken(string jwtBearer)
    {
        var jwtSecurityToken = new JwtSecurityTokenHandler().ReadToken(jwtBearer) as JwtSecurityToken;

        if (jwtSecurityToken is null) return;

        JwtBearer = new JwtBearerModel(Convert.ToInt32(jwtSecurityToken.Claims.First(c => c.Type == "nameid").Value), jwtSecurityToken.Claims.First(c => c.Type == "unique_name").Value, jwtSecurityToken.Claims.First(c => c.Type == "role").Value);
    }
}
