using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.Repositories.Intarfaces
{
    public interface IOerderRepository
    {
        Task<IEnumerable<Order?>> GetAllAsync(int userId);
        Task<bool> DeleteAsync(int orderId, int giftId, int amount);
        Task<Order?> GetDraftOrderByUserAsync(int userId);
        Task<Order> CreateDraftOrderAsync(int userId);
        Task AddOrUpdateGiftInOrderAsync(int orderId, int giftId, int amount);
        Task<Order?> GetByIdWithGiftsAsync(int orderId);
        Task<bool> ComleteOrder(int orderId);
    }
}


