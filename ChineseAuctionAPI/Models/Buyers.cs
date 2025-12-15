using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Buyers
    {
        [Key]
        public int IdBayer { get; set; }
        public string Identity { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string PhonNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        
    }
}
