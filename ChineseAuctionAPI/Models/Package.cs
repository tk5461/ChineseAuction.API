using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Package
    {
        [Key]
        public int IdPackage { get; set; }
        public ICollection<Card> Cards { get; set; }   
        public string Name { get; set; } 
        public string? Description { get; set; }
        public int Amount_Regular { get; set; }
        public ICollection<Package_Order> PackageOrders { get; set; }
        public int? Amount_Premium { get; set; }
        public int Price { get; set; }

    }
}
