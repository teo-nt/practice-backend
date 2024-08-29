using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.DTO;
using MovieAPI.Models;
using MovieAPI.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User?> LogIn(UserLoginDTO user)
        {
           return await _unitOfWork.UserRepository.LogIn(user.Username, user.Password);
        }

        public string CreateToken(User user, IConfigurationSection settings)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.GetSection("tokenKey").Value!));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, ((user.Username == "admin") ? "admin" : "user"))
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<User?> Register(UserRegisterDTO registerDTO)
        {
            var existingUser = await _unitOfWork.UserRepository.GetByUsername(registerDTO.Username);
            if (existingUser != null)
            {
                throw new Exception("User with the same username already exists");
            }

            User userToRegister = new()
            {
                Username = registerDTO.Username,
                Password = Security.Security.HashPassword(registerDTO.Password),
            };
            User? registeredUser = await _unitOfWork.UserRepository.Register(userToRegister);
            await _unitOfWork.SaveAsync();
            return registeredUser;
        }
    }
}
