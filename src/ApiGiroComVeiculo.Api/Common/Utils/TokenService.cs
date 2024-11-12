using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiGiroComVeiculo.Api.Common.Utils;

public static class TokenService
{
    private static string? _jwtKey;

    public static void Configure(IConfiguration config)
    {
        _jwtKey = config.GetValue<string>("SecretsApi:SecretKey")!;
    }

    public static string GenerateToken(string cnpj, string plate)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtKey!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new ("cnpj", cnpj.ToString()),
                new ("plate", plate.ToString()),
            ]),

            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public static Dictionary<string, string> GetTokenProperties(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtKey!);

        var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        }, out var validatedToken);

        var claims = principal.Claims;

        return claims.ToDictionary(c => c.Type, c => c.Value);
    }

}
