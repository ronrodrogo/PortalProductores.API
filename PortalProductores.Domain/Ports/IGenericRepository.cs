using System.Linq.Expressions;

namespace PortalProductores.Domain.Ports
{
    public interface IGenericRepository<E> : IDisposable
        where E : class
    {
        Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>>? filter = null, bool isTracking = false);
        Task<E> GetByFilterAsync(Expression<Func<E, bool>> alternateKey);
        Task<E> CreateAsync(E entity);
        Task<IEnumerable<E>> CreateRangeAsync(IEnumerable<E> entity);
        Task<E> UpdateAsync(E entity);
        Task DeleteAsync(E entity);
        Task DeleteAsync(Expression<Func<E, bool>> filter);
    }
}
