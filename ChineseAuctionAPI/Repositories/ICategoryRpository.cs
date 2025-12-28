using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.Repositories
{
    public interface ICategoryRpository
    {
        Task<IEnumerable<GiftCategory>> GetAllAsync();
        Task<GiftCategory?> GetByIdAsync(int id);
        Task<GiftCategory> AddAsync(GiftCategory category);
        Task<bool> UpdateAsync(GiftCategory category);
        Task<bool> DeleteAsync(int id);
    }
}
