using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Enums;
using PortalProductores.Domain.Exceptions;
using PortalProductores.Domain.Helpers;
using PortalProductores.Domain.Ports;

namespace PortalProductores.Domain.Services
{
    [DomainService]
    public class ProductorService(
        IGenericRepository<Productor> _productorRepository
    )
    {
        public async Task<IEnumerable<Productor>> GetAllProductoresPadresAsync()
        {
            return await _productorRepository.GetAsync(
                filter => filter.ProductorPadreId == null && filter.Estado.Equals(1)
            );
        }

        public async Task<IEnumerable<Productor>> GetProductoresHijosByProductorPadreIdAsync(int productorPadreId)
        {
            productorPadreId.ValidateInvalidId();

            return await _productorRepository.GetAsync(
                filter => filter.ProductorPadreId.Equals(productorPadreId) && filter.Estado.Equals(1)
            );
        }

        public async Task DeleteProductorByIdAsyync(int productorId)
        {
            productorId.ValidateInvalidId();

            Productor productor = await GetProductorByIdAsync(productorId);
            productor.Estado = (int)EstadoTypes.Inactivo;

            await _productorRepository.UpdateAsync(productor);
        }

        private async Task<Productor> GetProductorByIdAsync(int id)
        {
            id.ValidateInvalidId();

            Productor productor = await _productorRepository.GetByFilterAsync(
                filter => filter.Id.Equals(id) && filter.Estado.Equals(1)
            ) ?? throw new ValidatorException(MessagesExceptions.ProducerNotExists);

            return productor;
        }
    }
}
