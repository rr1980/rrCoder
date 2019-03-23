using Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DB
{

    public interface IRepository
    {
        Task<T> GetById<T>(long id) where T : BaseEntity;
        IQueryable<T> GetAll<T>() where T : BaseEntity;
        Task Create<T>(T entity) where T : BaseEntity;
        Task Update<T>(T entity) where T : BaseEntity;
        Task Remove<T>(T entity) where T : BaseEntity;
    }
}
