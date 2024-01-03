using InventoryMGMT_SYSTEM.NET.Models;
using InventoryMGMT_SYSTEM.NET.DTOs;
using InventoryMGMT_SYSTEM.NET.Repository.UserRepository;
using InventoryMGMT_SYSTEM.NET.Enum.RegistrationEnum;


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
            if (_userRepository.UsernameExists(registerUserDTO.UserName))
            {
                // Throw an exception indicating that the username is already taken
                throw new InvalidOperationException($"Username '{registerUserDTO.UserName}' is already taken. Please choose a different one."); 
            }
            if (_userRepository.EmailExists(registerUserDTO.Email)) 
            {
                throw new InvalidOperationException("This Email is already being used. Please choose a different one.");
            }

            var newUser = new User
            {
                Username = registerUserDTO.UserName,
                Email = registerUserDTO.Email,
                Password = registerUserDTO.Password,
                UserType = "User",
            };

            return _userRepository.CreateUser(newUser);
        }


        public int UnregisterUser(int userId)
        {
            //if {this function(returns true)} {
            // means user exists reutrn error
            //}
            _userRepository.DeleteUser(userId);
            return userId;
        }


    }
}
