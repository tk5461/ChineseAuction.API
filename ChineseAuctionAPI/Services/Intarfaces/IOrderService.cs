using ChineseAuctionAPI.DTO;

namespace ChineseAuctionAPI.Services.Intarfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllAsync(int userId);
        Task<bool> DeleteAsync(int orderId, int giftId, int amount);
        Task<IEnumerable<OrderDTO>> GetDraftOrderByUserAsync(int userId); 
      //Task<OrderDTO> CreateDraftOrderAsync(int userId); 
        Task<bool> AddOrUpdateGiftInOrderAsync(int orderId, int giftId, int amount);
        Task<OrderDTO?> GetByIdWithGiftsAsync(int orderId);
        Task<bool> CompleteOrder(int orderId);
    }
}

