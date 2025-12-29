using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.Services.Intarfaces
    {
        public interface ICategoryService
        {
            Task<IEnumerable<GiftCategory>> GetAllAsync();
            Task<GiftCategory?> GetByIdAsync(int id);
            Task<GiftCategory> AddAsync(CategoryDTO category);
            Task<bool> UpdateAsync(int id, GiftCategory category);
            Task<bool> DeleteAsync(int id);
        }
    }


