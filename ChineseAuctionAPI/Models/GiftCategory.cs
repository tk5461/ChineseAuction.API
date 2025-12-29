using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class GiftCategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
