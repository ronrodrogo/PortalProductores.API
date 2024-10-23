using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Ports;

namespace PortalProductores.Domain.Services
{
    [DomainService]
    public class TemporadaService(IGenericRepository<Temporada> _temporadaRepository)
    {
        public async Task<IEnumerable<Temporada>> GetTemporadasAsync()
        {
            return await _temporadaRepository.GetAsync();
        }
    }
}
