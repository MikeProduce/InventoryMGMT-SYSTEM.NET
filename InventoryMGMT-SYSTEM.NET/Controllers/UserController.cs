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
        public IActionResult Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            try
            {
                var newUser = _userService.RegisterUser(registerUserDTO);
                return Ok(newUser); // You may customize the response based on your requirements
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
