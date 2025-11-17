using Comercio.Repository.Repositories.Interfaces;
using Comercio.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Comercio.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly Context _context;
        public BaseRepository(Context context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entidade)
        {
            var respost = await _context.Set<T>().AddAsync(entidade);
            await _context.SaveChangesAsync();
            return respost.Entity;
        }

        public async Task DeleteAsync(T entidade)
        {
            _context.Set<T>().Remove(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllASync()
        {
            var respost = await _context.Set<T>().ToListAsync();
            return respost;
        }

        public Task<T?> GetByIdAsync(long id)
        {
            var respost = _context.Set<T>().FirstOrDefaultAsync(x => EF.Property<long>(x, "Id") == id);
            return respost;
        }

        public async Task<T> UpdateAsync(T entidade)
        {
            _context.Set<T>().Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }
    }
}