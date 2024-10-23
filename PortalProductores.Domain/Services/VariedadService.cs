using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Ports;

namespace PortalProductores.Domain.Services
{
    [DomainService]
    public class VariedadService(IGenericRepository<Variedad> _variedadRepository)
    {
        public async Task<IEnumerable<Variedad>> GetVariedadesAsync()
        {
            return await _variedadRepository.GetAsync();
        }
    }
}
