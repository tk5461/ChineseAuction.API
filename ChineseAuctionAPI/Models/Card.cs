using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class Card
    {
        [Key]
        public int CurdId { get; set; }
        public int userId { get; set; }
        public int IdGift { get; set; }
        public int price { get; set; }
    }
}

