using _253504_Antikhovitch.Persistense.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.Persistense.Repository
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;

        protected readonly DbSet<T> _entities;

        public EfRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>>? filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includesProperties)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if (includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in includesProperties)
                {
                    query = query.Include(included);
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<T>? query = _entities.AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includesProperties)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if (includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in includesProperties)
                {
                    query = query.Include(included);
                }
            }
            return await query.SingleAsync(i => i.Id == id, cancellationToken);
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Added;
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _entities.AsQueryable();

            return query.FirstOrDefaultAsync(filter, cancellationToken)!;
        }
    }
}
