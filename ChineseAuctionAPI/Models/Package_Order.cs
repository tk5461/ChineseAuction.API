using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuctionAPI.Models
{
    public class Package_Order
    {
            [Key]
            public int IdPackageOrder { get; set; }
            public int OrderId { get; set; }
            [ForeignKey("OrderId")]
            public virtual Order Order { get; set; }
            public int IdPackage { get; set; }
            [ForeignKey("IdPackage")]
            public virtual Package Package { get; set; }
            public int Quantity { get; set; } = 1;
            public int PriceAtPurchase { get; set; }
        }
    }
