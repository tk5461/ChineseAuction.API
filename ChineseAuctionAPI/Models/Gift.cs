using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ChineseAuctionAPI.Models
{
    public enum GiftCategory
    {
        Electronics,
        HomeGoods,
        Vacation,
        Jewelry,
        Other
    }
    public class Gift 
    {
        [Key]
        public int IdGift { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public GiftCategory Category { get; set; }
        public int Qeuntity { get; set; } = 1;
        public int price { get; set; }
        public string? Image { get; set; } 
        [ForeignKey("IdDonor")]
        public int IdDonor { get; set; }
        public  Donor Donor { get; set; }
        public bool IsDrawn { get; set; } = false;
        public int? WinnerUserId { get; set; }
        public ICollection<Gift_Order> GiftOrders { get; set; }
    }
}

