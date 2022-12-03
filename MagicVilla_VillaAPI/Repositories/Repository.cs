using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true, string includeProperties = null)
        {
            var query = dbSet.AsQueryable<T>();
            if (!tracked)
                query = query.AsNoTracking();
            if (filter != null)
                query = query.Where(filter);
            return (await query.FirstOrDefaultAsync())!;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string includeProperties = null)
        {
            var query = dbSet.AsQueryable<T>();

            if (filter != null)
                query = query.Where(filter);
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
