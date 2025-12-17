using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuctionAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("IdBayer")]
        public int IdBayer { get; set; }
        public User Buyers { get; set; }  
        public int IdPackage { get; set; }
        public Package Packages { get; set; } 
        public int AmountOrders { get; set; }
        public DateTime dateTime { get; set; }
        public bool IsStatusDraft { get; set; }
        public virtual ICollection<Gift_Order> GiftsInCart { get; set; }
    }
}
