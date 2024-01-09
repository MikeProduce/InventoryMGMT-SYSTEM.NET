using InventoryMGMT_SYSTEM.NET.Models;

namespace InventoryMGMT_SYSTEM.NET.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        int DeleteUser(int userId);
        Task<bool> EmailExists(string email);
        Task<bool> UsernameExists(string username);
        Task<string> GetPasswordByUsername(string username);
        Task<string> GetPasswordByEmail(string email);

        //Task<string> AreCredentialsValid(string username, string password);
    }

}
