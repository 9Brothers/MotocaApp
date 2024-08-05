using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Motoca.Core.Domain.Utils;

public class AuthUtils
{
    public static string GenerateToken(List<Claim> claims)
    {
        var secret = Environment.GetEnvironmentVariable("JWT_SECRET");

        if (string.IsNullOrEmpty(secret?.Trim()))
            throw new Exception("Informe uma secret para o JWT.");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),                
            Expires = DateTime.UtcNow.AddMonths(6),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}