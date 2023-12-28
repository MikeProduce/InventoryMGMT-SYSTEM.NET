using InventoryMGMT_SYSTEM.NET.Models;
using InventoryMGMT_SYSTEM.NET.DTOs;
using InventoryMGMT_SYSTEM.NET.Repository.UserRepository;

namespace InventoryMGMT_SYSTEM.NET.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public User RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var newUser = new User
            {
                Username = registerUserDTO.UserName,
                Email = registerUserDTO.Email,
                Password = registerUserDTO.Password,
                UserId = registerUserDTO.UserId,
                UserType = registerUserDTO.UserType,
            };

            return _userRepository.CreateUser(newUser);
        }
    }
}
