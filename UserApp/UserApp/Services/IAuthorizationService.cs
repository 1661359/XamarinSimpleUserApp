using System.Threading.Tasks;

namespace UserApp.Services
{
    public interface IAuthorizationService
    {
        Task Login(string userName);

        void Logout();
    }
}