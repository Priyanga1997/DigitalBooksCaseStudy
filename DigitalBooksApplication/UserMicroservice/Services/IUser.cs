using UserMicroservice.Models;

namespace UserMicroservice.Services
{
    public interface IUser
    {
        Task<string> LoginAsync(User login, bool IsRegister);
        Task<string> RegisterAsync(User login, bool IsRegister);
    }
}
