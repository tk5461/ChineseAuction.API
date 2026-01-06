using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuctionAPI.Models
{
    public class Gift
    {
        [Key] 
        public int IdGift { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "שם המתנה לא יכול לעלות על 100 תווים")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))] 
        public GiftCategory Category { get; set; }
        [Range(1, 1000, ErrorMessage = "הכמות חייבת להיות לפחות 1")]
        public int Quantity { get; set; } = 1;
        [Range(0, 10000, ErrorMessage = "המחיר אינו יכול להיות שלילי")]
        public int price { get; set; } 
        public string? Image { get; set; }
        [Required]
        public int IdDonor { get; set; }

        [ForeignKey(nameof(IdDonor))] 
        public Donor Donor { get; set; }
        public bool IsDrawn { get; set; } = false;
        public int? userId { get; set; }  
        [ForeignKey(nameof(userId))]
        public User? User { get; set; }
        public ICollection<Gift_Order> GiftOrders { get; set; } 
    }
}


