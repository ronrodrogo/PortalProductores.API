using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Enums;
using PortalProductores.Domain.Exceptions;
using PortalProductores.Domain.Helpers;
using PortalProductores.Domain.Ports;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PortalProductores.Infrastructure.Adapters
{
    public class JwtGenerator(IConfiguration _config) : IJwtGenerator
    {
        private readonly SymmetricSecurityKey _key = new(Encoding.UTF8.GetBytes(_config.GetValue<string>("JWT_SECRET_KEY")!));

        public string GenerateToken(Usuario usuario)
        {
            List<Claim> claims =
            [
                new("Id", usuario.Id.ToString()),
                new("Nombre", usuario.Nombre),
                new("Correo", usuario.Correo),
                new("Telefono", usuario.Telefono!),
                new("Rut", usuario.Rut),
                new("Perfil", ((PerfilTypes)usuario.Perfil).GetDescription())
            ];

            var expiracion = DateTime.UtcNow.AddHours(24);
            SigningCredentials creds = new(_key, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken securityToken = new(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: creds);

            JwtSecurityTokenHandler tokenHandler = new();

            return tokenHandler.WriteToken(securityToken);
        }

        public ClaimsPrincipal DeserializeToken(string token)
        {
            token = token["Bearer ".Length..].Trim();
            var tokenHandler = new JwtSecurityTokenHandler();

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _key,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            }, out SecurityToken validatedToken);

            return validatedToken is JwtSecurityToken jwtToken
                ? new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims))
                : throw new AppException(MessagesExceptions.InvalidToken);
        }
    }
}
