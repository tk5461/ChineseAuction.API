using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ChineseAuctionAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User_DTO>> GetAllAsync();
        Task<User_DTO?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<DTOuserOrder?> GetUserWirhOrdersAsync(int userId);
        Task<string?> RegisterAsync(LoginUserDTO dto);
        Task<string?> LoginAsync(string email, string password);
    }
}


