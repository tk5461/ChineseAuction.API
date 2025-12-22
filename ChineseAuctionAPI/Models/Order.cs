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
        public int userId { get; set; }
        public User User { get; set; }  
        public  ICollection<Package_Order> Package_Order { get; set; }
        public int price { get; set; } = 1;
        public DateTime dateTime { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Draft;
        public virtual ICollection<Gift_Order> GiftsInCart { get; set; } 
    }
}


