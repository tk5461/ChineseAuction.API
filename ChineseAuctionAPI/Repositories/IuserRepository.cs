using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.Repositories
{
    public interface IuserRepository
    {
        Task<User> AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> EmailExistsAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<User?> GetUserWirhOrdersAsync(int userId);
    }
}
