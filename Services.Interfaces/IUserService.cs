using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        IEnumerable<Bemerkung> GetAllBemerkungen();
        Task<User> GetById(int id);
        Task Add();
    }
}
