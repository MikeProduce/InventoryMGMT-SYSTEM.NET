using Microsoft.AspNetCore.Mvc;
using InventoryMGMT_SYSTEM.NET.DTOs;
using InventoryMGMT_SYSTEM.NET.Services.UserServices;


namespace InventoryMGMT_SYSTEM.NET.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            try
            {
                var newUser =  await _userService.RegisterUser(registerUserDTO);
                return CreatedAtAction(nameof(Register), new { id = newUser.UserId }, newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            try
            {
                bool authenticateUser = await _userService.AuthenticateUser(loginUserDTO);
                return Ok(authenticateUser);
            }
            catch (Exception ex)
            {
                return Unauthorized($"Authentication Failed: {ex.Message}");
            }
        }

        // Delete 
        [HttpDelete("unregister")]
        public IActionResult Unregister([FromBody] UnregisterUserDTO unregisterUserDTO)
        {
            try
            {
                var deleteUser = _userService.UnregisterUser(unregisterUserDTO.UserId);
                return Ok(deleteUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error:  {ex.Message}");
            }
        }


    }
}
