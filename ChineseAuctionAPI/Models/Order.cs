using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseAuctionAPI.Models
{
    public enum OrderStatus
    {
        Draft,
        Completed
    } 
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int userId { get; set; }
        [ForeignKey(nameof(userId))]
        public User User { get; set; }  
        public  ICollection<Package_Order> Package_Order { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "המחיר אינו יכול להיות שלילי")]
        public int price { get; set; } = 1;
        [Required]
        public DateTime dateTime { get; set; } = DateTime.Now;
        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Draft;
        public ICollection<Gift_Order> GiftsInCart { get; set; } 
    }
}


