using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Package
    {
        [Key]
        public int IdPackage { get; set; }
        public ICollection<Card> Cards { get; set;} 
        [Required]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "תיאור החבילה לא יכול לעלות על 500 תווים")]
        public string? Description { get; set; }
        [Range(0, 1000, ErrorMessage = "כמות כרטיסי פרימיום לא יכולה להיות שלילית")]
        public int Amount_Regular { get; set; }
        public ICollection<Package_Order> PackageOrders { get; set; }
        [Range(0, 1000, ErrorMessage = "כמות כרטיסי פרימיום לא יכולה להיות שלילית")]
        public int? Amount_Premium { get; set; }
        [Required]
        public int Price { get; set; }

    }
}
