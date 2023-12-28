using InventoryMGMT_SYSTEM.NET.Data;
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

        public User CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
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
