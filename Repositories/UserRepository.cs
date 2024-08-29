using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models;
using MovieAPI.Security;

namespace MovieAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _dataContext.Users.FirstOrDefaultAsync(u=> u.Username == username);
        }

        public async Task<User?> LogIn(string userName, string password)
        {
            
            var user = await _dataContext.Users.FirstOrDefaultAsync(user => (user.Username == userName));
            if (user == null)
            {
                return null;
            }
            if (!Security.Security.IsValidPassword(password, user.Password))
            {
                return null;
            }
            return user;
        }

        public async Task<User?> Register(User user)
        {
            return (await _dataContext.Users.AddAsync(user)).Entity;
        }
    }
}
