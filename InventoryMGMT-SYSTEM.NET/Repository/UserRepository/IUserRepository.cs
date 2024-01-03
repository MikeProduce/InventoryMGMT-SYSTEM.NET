using InventoryMGMT_SYSTEM.NET.Models;

namespace InventoryMGMT_SYSTEM.NET.Repository.UserRepository
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        int DeleteUser(int userId);
        bool EmailExists(string email);
        bool UsernameExists(string username);
    }

}
