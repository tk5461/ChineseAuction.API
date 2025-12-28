using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Repositories;

namespace ChineseAuctionAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOerderRepository _OrderRepository;
        private readonly IConfiguration _config;

        public OrderService(IOerderRepository oerderRepository, IConfiguration config)
        {
            _OrderRepository = oerderRepository;
            _config = config;
        }
        public async Task<bool> AddOrUpdateGiftInOrderAsync(int orderId, int giftId, int amount)
        {
            try
            {
                await _OrderRepository.AddOrUpdateGiftInOrderAsync(orderId, giftId, amount);
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error adding or updating gift in order.", ex);
            }
        }

        public async Task<bool> CompleteOrder(int orderId)
        {
            try
            {
                return await _OrderRepository.ComleteOrder(orderId);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error Comptle order.", ex);
            }
        }

        public async Task<bool> DeleteAsync(int orderId, int giftId, int amount)
        {
            try
            {
                return await _OrderRepository.DeleteAsync(orderId, giftId, amount);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error Delete order.", ex);
            }
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync(int userId)
        {
            try
            {
                var orders = await _OrderRepository.GetAllAsync(userId);

                var orderDTOs = orders.Select(o => new OrderDTO
                {
                    userId = o.userId,
                    dateTime = o.dateTime,
                    Status = o.Status,
                    orders = o.GiftsInCart.Select(oi => new OrderItemDTO
                    {
                        Name = oi.gifts.Name,
                        Description = oi.gifts.Description,
                        Category = oi.gifts.Category,
                        Amount = oi.Amount,
                        price = oi.gifts.price,
                        Image = oi.gifts.Image
                    }).ToList(),
                    TotalPrice = o.GiftsInCart.Sum(oi => oi.gifts.price * oi.Amount),
                    TotalAmount = o.GiftsInCart.Sum(oi => oi.Amount)
                }).ToList();
                return orderDTOs;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error GetAll order.", ex);

            }
        }

        public async Task<OrderDTO?> GetByIdWithGiftsAsync(int orderId)
        {
            try
            {
                var order = await _OrderRepository.GetByIdWithGiftsAsync(orderId);
                if (order == null) return null;
                var orderDTO = new OrderDTO
                {
                    dateTime = order.dateTime,
                    Status = order.Status,
                    orders = order.GiftsInCart.Select(oi => new OrderItemDTO
                    {
                        Name = oi.gifts.Name,
                        Description = oi.gifts.Description,
                        Category = oi.gifts.Category,
                        Amount = oi.Amount,
                        price = oi.gifts.price,
                        Image = oi.gifts.Image
                    }).ToList(),
                    TotalPrice = order.GiftsInCart.Sum(oi => oi.gifts.price * oi.Amount),
                    TotalAmount = order.GiftsInCart.Sum(oi => oi.Amount)
                };
                return orderDTO; 

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error GetByIdWithGiftsAsync order.", ex);
            }
        }

        public async Task<OrderDTO?> GetDraftOrderByUserAsync(int userId)
        {
            try
            {
                var draftOrder = await _OrderRepository.GetDraftOrderByUserAsync(userId);
                if (draftOrder == null) return null;

                return new OrderDTO
                {
                    userId = draftOrder.userId,
                    dateTime = draftOrder.dateTime,
                    Status = draftOrder.Status,
                    orders = draftOrder.GiftsInCart.Select(oi => new OrderItemDTO
                    {
                        Name = oi.gifts.Name,
                        Description = oi.gifts.Description,
                        Category = oi.gifts.Category,
                        Amount = oi.Amount,
                        price = oi.gifts.price,
                        Image = oi.gifts.Image
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving draft order for user {userId}.", ex);
            }
        }
    }
}
