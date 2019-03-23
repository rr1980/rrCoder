using System.Collections.Generic;
using System.Threading.Tasks;
using VievModels;

namespace Services.Interfaces
{
    public interface IBenutzerService
    {
        Task<BenutzerVievmodel> Authenticate(string username, string password);
        Task<List<BenutzerVievmodel>> GetAll();
        Task<BenutzerVievmodel> GetById(int id);
    }
}
