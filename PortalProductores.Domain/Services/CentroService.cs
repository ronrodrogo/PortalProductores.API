using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Ports;

namespace PortalProductores.Domain.Services
{
    [DomainService]
    public class CentroService(IGenericRepository<Centro> _centroRepository)
    {
        public async Task<IEnumerable<Centro>> GetCentrosAsync()
        {
            return await _centroRepository.GetAsync();
        }
    }
}
