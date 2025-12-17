using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuctionAPI.Models
{
    public class gifts
    {
        [Key]
        public int IdGift { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Qeuntity { get; set; } = 1;
        public string? Image { get; set; }
        [ForeignKey("IdDonor")]
        public int IdDonor { get; set; }
        public Donor Donors { get; set; }
        //צריך להוסיף רשימה של קונים 
    }
}
