using PortalProductores.Domain.Entities;
using System.Security.Claims;

namespace PortalProductores.Domain.Ports
{
    public interface IJwtGenerator
    {
        string GenerateToken(Usuario usuario);
        ClaimsPrincipal DeserializeToken(string token);
    }
}
