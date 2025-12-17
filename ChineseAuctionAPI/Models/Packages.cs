using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Packages
    {
        [Key]

        public int IdPackage { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Amount_Regular { get; set; } 
        public int? Amount_PrimPremium { get; set; }
        public int Price { get; set; }

    }
}
