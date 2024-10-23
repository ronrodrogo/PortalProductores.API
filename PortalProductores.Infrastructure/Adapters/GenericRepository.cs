using Microsoft.EntityFrameworkCore;
using PortalProductores.Domain.Ports;
using PortalProductores.Infrastructure.Context;
using System.Linq.Expressions;

namespace PortalProductores.Infrastructure.Adapters
{
    public class GenericRepository<E>(
        PersistenceContext _context
    ) : IGenericRepository<E> where E : class
    {
        public async Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>>? filter = null, bool isTracking = false)
        {
            IQueryable<E> query = _context.Set<E>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return (!isTracking) ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
        }

        public async Task<E> GetByFilterAsync(Expression<Func<E, bool>> alternateKey)
        {
            var entity = _context.Set<E>().AsNoTracking();

            return await entity.FirstOrDefaultAsync(alternateKey).ConfigureAwait(false);
        }

        public async Task<E> CreateAsync(E entity)
        {
            _context.Set<E>().Add(entity);
            await CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<E>> CreateRangeAsync(IEnumerable<E> entity)
        {
            _context.Set<E>().AddRange(entity);
            await CommitAsync();
            return entity;
        }

        public async Task<E> UpdateAsync(E entity)
        {
            _context.Set<E>().Update(entity);
            await CommitAsync();
            return entity;
        }

        public async Task DeleteAsync(E entity)
        {
            if (entity != null)
            {
                _context.Set<E>().Remove(entity);
                await CommitAsync().ConfigureAwait(false);
            }
        }

        public async Task DeleteAsync(Expression<Func<E, bool>> filter)
        {
            IQueryable<E> entities = _context.Set<E>();

            entities = entities.Where(filter);

            _context.Set<E>().RemoveRange(entities);

            await CommitAsync().ConfigureAwait(false);
        }

        public async Task CommitAsync()
        {
            _context.ChangeTracker.DetectChanges();

            await _context.CommitAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
