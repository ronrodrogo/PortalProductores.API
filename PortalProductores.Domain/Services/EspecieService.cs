using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Ports;

namespace PortalProductores.Domain.Services
{
    [DomainService]
    public class EspecieService(IGenericRepository<Especie> _especieRepository)
    {
        public async Task<IEnumerable<Especie>> GetEspeciesAsync()
        {
            return await _especieRepository.GetAsync();
        }
    }
}
