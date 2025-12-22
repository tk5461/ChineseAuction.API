using ChineseAuctionAPI.DTO;

namespace ChineseAuctionAPI.Services
{
    public class OrderService : IOrderService
    {
        public Task<bool> AddOrUpdateGiftInOrderAsync(int orderId, int giftId, int amount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CompleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int orderId, int giftId, int amount)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDTO>> GetAllAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO?> GetByIdWithGiftsAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO?> GetDraftOrderByUserAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
