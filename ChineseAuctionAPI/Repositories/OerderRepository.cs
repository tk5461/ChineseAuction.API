using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseAuctionAPI.Repositories
{
    public class OerderRepository : IOerderRepository
    {
        private readonly SalesContextDB _context;
        public OerderRepository(SalesContextDB context)
        {
            _context = context;
        }

        public async Task AddOrUpdateGiftInOrderAsync(int orderId, int giftId, int amount)
        {
            try
            {
               var gift = await _context.Gifts.FindAsync(giftId);
               var ord = await _context.Orders
                .Include(o => o.GiftsInCart)
               .FirstOrDefaultAsync(o => o.OrderId == orderId);

                var existing = ord.GiftsInCart.FirstOrDefault(go => go.IdGift == giftId);

                if (existing != null)
                {
                    existing.Amount += amount;
                    ord.price += (gift.price * amount);
                }
                else
                {
                    var newItem = new Gift_Order
                    {
                        IdGift = giftId,
                        OrderId = orderId,
                        Amount = amount,
                    };
                    _context.Gifts_Orders.Add(newItem);
                }
                ord.price += (gift.price * amount);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error adding or updating gift in order.", ex);
            }
        }

        public Task<bool> ComleteOrder(int orderId)
        {
            try
            {
                var order = _context.Orders.Find(orderId);
                if (order == null) return Task.FromResult(false);
                order.Status = OrderStatus.Completed;
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error completing order.", ex);
                throw;
            }
        }

        public async Task<Order> CreateDraftOrderAsync(int userId)
        {
            try
            {
                var order = new Order
                {
                    userId = userId,
                    Status = OrderStatus.Draft,
                    dateTime = DateTime.UtcNow,
                    GiftsInCart = new List<Gift_Order>() 
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return order;
            } 
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating draft order.", ex);         
            }
        }

        public async Task<bool> DeleteAsync(int orderId, int giftId, int amount)
        {
            try
            {
                var order = await _context.Orders
                    .Include(o => o.GiftsInCart)
                    .FirstOrDefaultAsync(o => o.OrderId == orderId);
                if (order == null) return false;
                var giftInOrder = order.GiftsInCart
                    .FirstOrDefault(go => go.IdGift == giftId);
                if (giftInOrder == null) return false;
                if (giftInOrder.Amount < amount) return false;

                var gift = await _context.Gifts.FindAsync(giftId);

                giftInOrder.Amount -= amount;
                order.price -= (gift.price * amount);
                if (giftInOrder.Amount == 0)
                {
                    _context.Gifts_Orders.Remove(giftInOrder);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting gift from order.", ex);
                return false;    
            }
        }

        public async Task<IEnumerable<Order?>> GetAllAsync(int userId)
        {
            try
            {
               return await _context.Orders
                    .Where(o => o.userId == userId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error retrieving orders for user.", ex);
            }
        }
        public async Task<Order?> GetByIdWithGiftsAsync(int orderId) 
        {
            try
            {
                return await _context.Orders
                    .Include(o => o.GiftsInCart) 
                        .ThenInclude(go => go.gifts)
                    .FirstOrDefaultAsync(o => o.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error adding gift in order.", ex);
            }
        }

        public async Task<Order?> GetDraftOrderByUserAsync(int userId)
        {
            try
            {
                return await _context.Orders
                    .Include(o => o.GiftsInCart) 
                        .ThenInclude(go => go.gifts)
                    .FirstOrDefaultAsync(o => o.userId == userId && o.Status == OrderStatus.Draft);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error retrieving draft order for user.", ex);
                throw;
            }
        }
    }
}
