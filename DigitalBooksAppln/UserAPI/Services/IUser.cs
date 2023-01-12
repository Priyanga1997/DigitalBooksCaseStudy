using UserAPI.Models;

namespace UserAPI.Services
{
    public interface IUser
    {
        Task<string> LoginAsync(User login, bool IsRegister);
        Task<string> RegisterAsync(User login, bool IsRegister);
    }
}
