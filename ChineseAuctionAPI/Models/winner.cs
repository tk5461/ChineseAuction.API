using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public class winner
    {
        [Key]

        public int IdWin { get; set; }
        public int userId { get; set; }
        public User user { get; set; } 
        public int IdGift { get; set; }
        public Gift gifts { get; set; }

    }
}
