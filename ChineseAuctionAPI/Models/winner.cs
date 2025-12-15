using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class winner
    {
        [Key]

        public int IdWin { get; set; }
        public int IdBayer { get; set; }
        public int IdGift { get; set; }

    }
}
