namespace ChineseAuctionAPI.DTO
    {
        public class GiftDTO
        {
            public string Name { get; set; } = string.Empty;
            public string? Description { get; set; }
            public int CategoryId { get; set; }
            public int Quantity { get; set; } = 1;
            public int Price { get; set; }
            public string? Image { get; set; }
            public int IdDonor { get; set; }
     }
}
