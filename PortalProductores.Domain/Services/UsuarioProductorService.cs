using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Enums;
using PortalProductores.Domain.Helpers;
using PortalProductores.Domain.Ports;

namespace PortalProductores.Domain.Services
{
    [DomainService]
    public class UsuarioProductorService(
        IQueryDapper _queryDapper
    )
    {
        public async Task<IEnumerable<UsuarioProductorDto>> GetListUsuarioProductorByUsuarioIdAsync(
            int usuarioId
        )
        {
            usuarioId.ValidateInvalidId();

            return await _queryDapper.QueryAsync<UsuarioProductorDto>(
                ItemQueryConstants.GetListUsuarioProductorByUsuarioId.GetDescription(),
                new { usuarioId }
            );
        }
    }
}
