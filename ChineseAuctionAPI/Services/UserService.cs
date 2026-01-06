using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using ChineseAuctionAPI.Services.Intarfaces;
using ChineseAuctionAPI.Repositories.Intarfaces;

namespace ChineseAuctionAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IuserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly ILogger<UserService> _logger;

        public UserService(IuserRepository userRepository, IConfiguration config, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _config = config;
            _logger = logger;
        }

        public async Task<string?> RegisterAsync(LoginUserDTO dto)
        {
            try
            {
                if (dto == null) throw new ArgumentNullException(nameof(dto));

                if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.password))
                    return null;

                var email = dto.Email.Trim();

                if (await _userRepository.EmailExistsAsync(email))
                    return null;

                var hashed = BCrypt.Net.BCrypt.HashPassword(dto.password);

                var newUser = new User
                {
                    Identity = dto.Identity,
                    FirstName = dto.First_Name,
                    LastName = dto.Last_Name,
                    password = hashed,
                    Email = email,
                    PhonNumber = dto.PhonNumber,
                    City = dto.City,
                    Address = dto.Address,
                    Orders = new List<Order>(),
                    cards = new List<Card>()
                };

                var created = await _userRepository.AddAsync(newUser);
                return GenerateJwtToken(created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בתהליך ההרשמה עבור אימייל: {Email}", dto?.Email);
                throw new Exception("אירעה שגיאה פנימית במהלך ההרשמה.");
            }
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                    return null;

                var u = await _userRepository.GetByEmailAsync(email.Trim());
                if (u == null) return null;

                if (!BCrypt.Net.BCrypt.Verify(password, u.password))
                    return null;

                return GenerateJwtToken(u);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בתהליך ההתחברות עבור אימייל: {Email}", email);
                throw new Exception("אירעה שגיאה במהלך ניסיון ההתחברות.");
            }
        }

        public async Task<IEnumerable<User_DTO>> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return users.Select(u => MapToUserDTO(u)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בשליפת כל המשתמשים");
                throw new Exception("אירעה שגיאה בעת שליפת המשתמשים.");
            }
        }

        public async Task<User_DTO?> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0) return null;
                var user = await _userRepository.GetByIdAsync(id);
                return user != null ? MapToUserDTO(user) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בשליפת משתמש לפי מזהה: {Id}", id);
                throw new Exception($"אירעה שגיאה בשליפת משתמש מזהה {id}.");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _userRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה במחיקת משתמש: {Id}", id);
                throw new Exception($"שגיאה במחיקת משתמש {id}.");
            }
        }

        public async Task<DTOuserOrder?> GetUserWirhOrdersAsync(int userId)
        {
            try
            {
                var u = await _userRepository.GetUserWithOrdersAndGiftsAsync(userId);
                if (u == null) return null;

                return new DTOuserOrder
                {
                    First_Name = u.FirstName,
                    Last_Name = u.LastName,
                    orders = u.Orders?.Select(o => new OrderDTO
                    {
                        Status = o.Status,
                        userId = o.userId,
                        dateTime = o.dateTime,
                        Items = o.GiftsInCart?.Select(g => new OrderItemDTO
                        {
                            Amount = g.Amount
                        }).ToList() ?? new List<OrderItemDTO>()
                    }).ToList() ?? new List<OrderDTO>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בשליפת הזמנות עבור משתמש: {UserId}", userId);
                throw new Exception($"נכשל בשליפת הזמנות עבור משתמש {userId}.");
            }
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSection = _config.GetSection("Jwt");
            var keyStr = jwtSection["Key"] ?? throw new InvalidOperationException("Jwt:Key is missing from configuration");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.userId.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim(ClaimTypes.Role, user.role.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSection["Issuer"],
                audience: jwtSection["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static User_DTO MapToUserDTO(User user)
        {
            return new User_DTO
            {
                Identity = user.Identity,
                First_Name = user.FirstName,
                Last_Name = user.LastName,
                Email = user.Email,
                PhonNumber = user.PhonNumber,
                City = user.City,
                Address = user.Address,
            };
        }
    }
}