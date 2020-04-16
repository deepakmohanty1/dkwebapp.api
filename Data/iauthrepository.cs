using System.Threading.Tasks;
using dkwebapp.api.models;

namespace dkwebapp.api.Data
{
    public interface iauthrepository
    {
       Task<usermaster> register(usermaster objuser, string password);
       Task<usermaster> login(string username, string password);
       Task<bool> userexists(string username);
    }
}