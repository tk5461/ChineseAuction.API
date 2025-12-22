using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChineseAuctionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        { 
            _userService = userService; 
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        [HttpGet("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetUserWirhOrdersAsync/{userId}")]
        public async Task<IActionResult> GetUserWithOrders(int userId)
        {
            var userWithOrders = await _userService.GetUserWirhOrdersAsync(userId);
            if (userWithOrders == null)
            {
                return NotFound();
            }
            return Ok(userWithOrders);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginUserDTO dto)
        {
            var resp = await _userService.RegisterAsync(dto);
            return Ok(resp);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO dto)
        {
            var resp = await _userService.LoginAsync(dto.Email , dto.password );
            return Ok(resp);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result)
            {
                return Ok("NotFound");
            }
            return Ok("delet well");
        }
    }
}

