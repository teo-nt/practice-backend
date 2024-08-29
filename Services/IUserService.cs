using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MovieAPI.DTO;
using MovieAPI.Models;

namespace MovieAPI.Services
{
    public interface IUserService
    {
        Task<User?> LogIn(UserLoginDTO user);
        string CreateToken(User user, IConfigurationSection settings);
        Task<User?> Register(UserRegisterDTO registerDTO);
    }
}
