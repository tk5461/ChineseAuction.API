using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories;

namespace ChineseAuctionAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IuserRepository _context;
       // private readonly ILogger<UserService> _logger; // טיפול בלוגים

        public UserService(IuserRepository context)
        {
            _context = context;
        }
        public Task<User> AddAsync(LoginUserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EmailExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User_DTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User_DTO?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User_DTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DTOuserOrder?> GetUserWirhOrdersAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
