using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.DTO
{
    public class OrderDTO
    {
        public OrderStatus Status { get; set; } = OrderStatus.Draft;
        public int userId { get; set; }        
        public DateTime dateTime { get; set; }
        public List<OrderItemDTO> orders { get; set; } = new();
    }
    public class OrderItemDTO
    {
        public int IdGift { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public GiftCategory Category { get; set; }
        public int Amount { get; set; } = 1;
        public int price { get; set; }
        public string? Image { get; set; }
        
    }
}
