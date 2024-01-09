using InventoryMGMT_SYSTEM.NET.Data;
using InventoryMGMT_SYSTEM.NET.DTOs;
using InventoryMGMT_SYSTEM.NET.Models;
using Microsoft.AspNetCore.Http.HttpResults;


namespace InventoryMGMT_SYSTEM.NET.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly InventoryMGMTDbContext _dbContext;
        public UserRepository(InventoryMGMTDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> EmailExists(string email)
        {
            return Task.FromResult(_dbContext.Users.Any(user => user.Email == email));
        }

        public  Task<bool> UsernameExists(string username)
        {
            return Task.FromResult(_dbContext.Users.Any(user => user.Username == username));
        }
        public Task<bool> GetUserPassword(string username)
        {
            return Task.FromResult(_dbContext.Users.Any(user => user.Username == username));
        }

        public Task<string> GetPasswordByUsername(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                return Task.FromResult(user.Password);
            }

            return Task.FromResult<string>(null);
        }
        public Task<string> GetPasswordByEmail(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                return Task.FromResult(user.Password);
            }

            return Task.FromResult<string>(null);
        }


        public async Task<User> CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        
        public int DeleteUser(int userId)
        {
            var user = _dbContext.Users.Where(u => u.UserId == userId).FirstOrDefault();

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return userId;
        }


    }

}
