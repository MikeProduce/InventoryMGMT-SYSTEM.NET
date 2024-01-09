using InventoryMGMT_SYSTEM.NET.Models;
using InventoryMGMT_SYSTEM.NET.DTOs;

namespace InventoryMGMT_SYSTEM.NET.Services.UserServices
{
    public interface IUserService
    {
        Task<User> RegisterUser(RegisterUserDTO registerUserDTO);
        int UnregisterUser(int userId);
        Task<bool> AuthenticateUser(LoginUserDTO loginUserDTO);

    }




}
