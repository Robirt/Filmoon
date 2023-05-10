using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Filmoon.WebAPI.Generators;

public static class JwtBearerGenerator
{
    public static string GenerateJwtBearer(int id, string userName, string roleName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(tokenHandler.CreateToken(new SecurityTokenDescriptor { Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, Convert.ToString(id)), new Claim(ClaimTypes.Name, userName), new Claim(ClaimTypes.Role, roleName) }), SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Y14bFU89F2pQnfdnFHFH")), SecurityAlgorithms.HmacSha256Signature), Issuer = "Filmoon", Expires = DateTime.UtcNow.AddDays(7) }));
    }
}
