using InventoryMGMT_SYSTEM.NET.Models;

namespace InventoryMGMT_SYSTEM.NET.Repository.UserRepository
{
    public interface IUserRepository
    {
        User CreateUser(User user);
    }
}
