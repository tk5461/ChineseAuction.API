using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuctionAPI.Models
{
    public class winner
    {
        [Key]
        public int IdWin { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User user { get; set; }
        [Required]
        public int IdGift { get; set; }
        [ForeignKey(nameof(IdGift))]
        public Gift gift { get; set; }
    }
}
