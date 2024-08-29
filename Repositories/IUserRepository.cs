using MovieAPI.Models;

namespace MovieAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User?> LogIn(string userName, string password);
        Task<User?> Register(User user);
        Task<User?> GetByUsername(string username);
    }
}
