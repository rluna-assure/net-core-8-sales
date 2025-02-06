using Microsoft.EntityFrameworkCore;
using SistemaVentas.Aplicacion.Interfaces;
using SistemaVentas.Aplicacion.Utils;
using SistemaVentas.Infraestructura.Persistencia;
using System.Linq.Expressions;

namespace SistemaVentas.Infraestructura.Repositorios
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<T>> GetPagedAsync(int pageNumber, int pageSize, params Expression<Func<T, bool>>[] filters)
        {
            IQueryable<T> query = _dbSet;
            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }
            var totalItems = await _dbSet.CountAsync();
            var items = await _dbSet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<T>(items, totalItems, pageNumber, pageSize);
        }
    }
}
