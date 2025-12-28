using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChineseAuctionAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IuserRepository _userRepository;
        private readonly IConfiguration _config;

        public UserService(IuserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<string?> RegisterAsync(LoginUserDTO dto)
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
            var token = GenerateJwtToken(created);

            return token;
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            var u = await _userRepository.GetByEmailAsync(email.Trim());
            if (u == null) return null;

            if (!BCrypt.Net.BCrypt.Verify(password, u.password))
                return null;

            var token = GenerateJwtToken(u);

            return token;
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSection = _config.GetSection("Jwt");
            var keyStr = jwtSection["Key"] ?? throw new InvalidOperationException("Jwt:Key is missing from configuration");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var isManager = (user.role == Role.Manager).ToString().ToLower();

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
        //return new User_DTO
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
        //get all users
        public async Task<IEnumerable<User_DTO>> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return users.Select(u => MapToUserDTO(u)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all users.", ex);
                throw;
            }

        }
        public async Task<User_DTO?> GetByIdAsync(int id)
        {
            if (id <= 0) return null;
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                return user != null ? MapToUserDTO(user) : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Id מזהה {id}", ex);
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
                throw new Exception($"error delete user {id}", ex);
            }
        }
        public async Task<DTOuserOrder?> GetUserWirhOrdersAsync(int userId)
        {
            try
            {
                var u = await _userRepository.GetUserWirhOrdersAsync(userId);
                if (u == null) return null;

                return new DTOuserOrder
                {
                    First_Name = u.FirstName ,
                    Last_Name = u.LastName ,
                    orders = u.Orders?
                        .Select(o => new OrderDTO
                        {
                            Status = o.Status,
                            userId = o.userId,
                            dateTime = o.dateTime,
                            orders = o.GiftsInCart?
                                .Select(g => new OrderItemDTO
                                {
                                    Amount = g.Amount,
                                   //price = g.price
                                })
                                .ToList() ?? new List<OrderItemDTO>()
                        })
                        .ToList() ?? new List<OrderDTO>()
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve user orders for ID: {userId}. Error: {ex.Message}", ex);
            }
        }
    } 
}

