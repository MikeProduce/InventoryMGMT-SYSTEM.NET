using InventoryMGMT_SYSTEM.NET.Models;
using InventoryMGMT_SYSTEM.NET.DTOs;
using InventoryMGMT_SYSTEM.NET.Repository.UserRepository;
using InventoryMGMT_SYSTEM.NET.Utility.PasswordHasher;

namespace InventoryMGMT_SYSTEM.NET.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            if (await _userRepository.UsernameExists(registerUserDTO.UserName))
            {
                // Throw an exception indicating that the username is already taken
                throw new InvalidOperationException($"Username '{registerUserDTO.UserName}' is already taken. Please choose a different one."); 
            }
            if (await _userRepository.EmailExists(registerUserDTO.Email)) 
            {
                throw new InvalidOperationException("This Email is already being used. Please choose a different one.");
            }

            string hashedPassword = PasswordHasher.HashPassword(registerUserDTO.Password);

            var newUser = new User
            {
                Username = registerUserDTO.UserName,
                Email = registerUserDTO.Email,
                Password = hashedPassword,
                UserType = "User",
            };

            return await _userRepository.CreateUser(newUser);

        }

        public async Task<bool> AuthenticateUser(LoginUserDTO loginUserDTO)
        {
            string hashedPassword;

            // Check if the provided credentials are valid
            if (!string.IsNullOrEmpty(loginUserDTO.UserName))
            {
                // If username is provided, attempt to authenticate using username
                hashedPassword = await _userRepository.GetPasswordByUsername(loginUserDTO.UserName);

                if (ValidatePassword(loginUserDTO.Password, hashedPassword))
                {
                    return true;
                }
            }
            else if (!string.IsNullOrEmpty(loginUserDTO.Email))
            {
                // If username is not provided but email is provided, attempt to authenticate using email
                hashedPassword = await _userRepository.GetPasswordByEmail(loginUserDTO.Email);

                if (ValidatePassword(loginUserDTO.Password, hashedPassword))
                {
                    return true;
                }
            }

            // Invalid credentials
            throw new InvalidOperationException("Invalid username or password.");
        }


        public bool ValidatePassword(string password, string hashedPassword)
        {
            // Use BCrypt to verify the password
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
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
