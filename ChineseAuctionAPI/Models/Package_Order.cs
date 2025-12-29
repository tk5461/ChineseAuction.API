using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuctionAPI.Models
{
    public class Package_Order
    {
            [Key]
            public int IdPackageOrder { get; set; }
            [Required] 
            public int OrderId { get; set; }
            [ForeignKey(nameof(OrderId))]
            public virtual Order Order { get; set; }
          [Required]
           public int IdPackage { get; set; }
            [ForeignKey(nameof(IdPackage))]
            public virtual Package Package { get; set; }
            [Required]
            [Range(1, 100, ErrorMessage = "כמות חבילות בהזמנה חייבת להיות בין 1 ל-100")]
             public int Quantity { get; set; } = 1;
            [Required]
        [Range(0, 50000, ErrorMessage = "המחיר בעת הרכישה אינו יכול להיות שלילי")]
        public int PriceAtPurchase { get; set; }
        }
    }

