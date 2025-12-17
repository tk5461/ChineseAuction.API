using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Gift_Order
    {
        [Key]
        public int IdGiftOrder { get; set; }
        public int IdGift { get; set; }
        public Gift gifts { get; set; }   
        public int OrderId { get; set; }
        public Order Orders { get; set; }
        public int Amount { get; set; }
    }
}

