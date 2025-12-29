using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuctionAPI.Models
{
    public class Gift_Order
    {
        [Key]
        public int IdGiftOrder { get; set; }
        [Required]
        public int IdGift { get; set; }
        [ForeignKey(nameof(IdGift))]
        public Gift gifts { get; set; }
        [Required]
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}

