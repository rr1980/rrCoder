using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Benutzer Authenticate(string username, string password);
        IEnumerable<Benutzer> GetAll();
        IEnumerable<Bemerkung> GetAllBemerkungen();
        Task<Benutzer> GetById(int id);
        Task Add();
    }
}
