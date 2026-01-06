using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories.Intarfaces;
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

        public async Task AddOrUpdateGiftInOrderAsync(int userId, int IdGift, int amount)
        {
            var ord = await _context.Orders
                .Include(o => o.GiftsInCart)
                .FirstOrDefaultAsync(o => o.userId == userId && o.Status == OrderStatus.Draft);

            if (ord == null)
            {
                ord = new Order
                {
                    userId = userId,
                    price = 0,
                    dateTime = DateTime.Now,
                    Status = OrderStatus.Draft,
                    GiftsInCart = new List<Gift_Order>() 
                };
                _context.Orders.Add(ord);
            }

            var existing = ord.GiftsInCart?.FirstOrDefault(go => go.IdGift == IdGift);

            if (existing != null)
                existing.Amount += amount;

            else
            {
                var newItem = new Gift_Order
                {
                    IdGift = IdGift,
                    Amount = amount,
                    OrderId = ord.OrderId // ה-EF יקשר זאת אוטומטית
                };
                ord.GiftsInCart.Add(newItem);
            }

            // 5. עדכון המחיר הכללי של ההזמנה ושמירה
            var gift = await _context.Gifts.FindAsync(IdGift);
            if (gift != null)
            {
                ord.price += (gift.price * amount);
            }

            await _context.SaveChangesAsync();
        }
        public async Task<bool> ComleteOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order == null || order.Status == OrderStatus.Completed) return false; 
            order.Status = OrderStatus.Completed;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Order> CreateDraftOrderAsync(int userId)
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

        public async Task<bool> DeleteAsync(int orderId, int giftId, int amount)
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

        public async Task<IEnumerable<Order?>> GetAllAsync(int userId)
        {
               return await _context.Orders
                    .Where(o => o.userId == userId)
                    .ToListAsync();
        }
        public async Task<Order?> GetByIdWithGiftsAsync(int orderId) 
        {
                 return await _context.Orders
                    .Include(o => o.GiftsInCart) 
                        .ThenInclude(go => go.gifts)
                    .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetDraftOrderByUserAsync(int userId)
        {
            return await _context.Orders
                .Where(o => o.userId == userId)
                .Include(o => o.GiftsInCart)
                    .ThenInclude(og => og.gifts)
                        .ThenInclude(g => g.Category)
                .ToListAsync();
    }

    }
}
