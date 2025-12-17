using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ChineseAuctionAPI.Services
{
    public interface IUserService
    {
        Task<User> AddAsync(LoginUserDTO user);
        Task<User_DTO?> GetByEmailAsync(string email);
        Task<bool> EmailExistsAsync(string email);
        Task<IEnumerable<User_DTO>> GetAllAsync();
        Task<User_DTO?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<DTOuserOrder?> GetUserWirhOrdersAsync(int userId);
    }
}


