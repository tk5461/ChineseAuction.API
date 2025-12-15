using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuctionAPI.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("IdBayer")]
        public int IdBayer { get; set; }
        public Buyers Buyers { get; set; }  
        public int IdPackage { get; set; }
        public Packages Packages { get; set; } 
        public int AmountOrders { get; set; }
        public DateTime dateTime { get; set; }
    }
}
