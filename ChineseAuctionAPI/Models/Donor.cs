using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Donor
    {
        [Key]
        public int IdDonor { get; set; }
        public string F_name { get; set; }
        public string L_name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string phonNumber { get; set; }
    }
}
