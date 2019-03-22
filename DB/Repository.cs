using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DB
{
    public class Repository : IRepository
    {
        protected readonly RRCoderDBContext _context;

        public Repository(RRCoderDBContext context)
        {
            _context = context;
        }

        public async Task<T> GetById<T>(long id) where T : BaseEntity
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<T> GetAll<T>() where T : BaseEntity
        {
            return _context.Set<T>();
        }

        public async Task Create<T>(T entity) where T : BaseEntity
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update<T>(T entity) where T : BaseEntity
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove<T>(T entity) where T : BaseEntity
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
