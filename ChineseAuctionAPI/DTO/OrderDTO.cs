namespace ChineseAuctionAPI.DTO
{
    public class OrderDTO
    {
        public bool IsStatusDraft { get; set; } = false;
        public int userId { get; set; }        
        public DateTime dateTime { get; set; }
        public List<OrderItemDTO>  orders { get; set; }
    }
    public class OrderItemDTO
    {
        public int IdGift { get; set; }
        public int Amount { get; set; } = 1;
        public int price { get; set; }

    }
}
