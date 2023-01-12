using DigitalBooksAppln.Models;

namespace DigitalBooksAppln.Services
{
    public interface IUsers
    {
        Task<LoginModel> LoginAsync(User login, bool IsRegister);
        Task<string> RegisterAsync(User login, bool IsRegister);
    }
}
