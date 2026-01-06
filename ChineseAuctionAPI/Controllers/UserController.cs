using System.Threading.Tasks;
using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Services.Intarfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChineseAuctionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService , ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;

        }

        [HttpGet("GetAllAsync")]
        [Authorize(Roles = "Manager")]

        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error get all users");
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginUserDTO dto)
        {
            try
            {
                var resp = await _userService.RegisterAsync(dto);
                _logger.LogInformation("User registered successfully");
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Register");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO dto)
        {
            try
            {
                var resp = await _userService.LoginAsync(dto.Email, dto.password);
                _logger.LogInformation("User logged in successfully");
                return Ok(resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error login");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var result = await _userService.DeleteAsync(id);
                if (!result)
                {
                    return Ok("NotFound");
                }
                return Ok("delet well");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Delet user", id);
                return StatusCode(500, ex.Message);
            }
        }
    }
}