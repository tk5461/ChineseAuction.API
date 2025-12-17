using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Gifts_Orders
    {
        [Key]

        public int IdGiftOrder { get; set; }
        public int IdGift { get; set; }
        public gifts gifts { get; set; }   
        public int OrderId { get; set; }
        public Orders Orders { get; set; }
        public int Amount { get; set; }
    }
}

