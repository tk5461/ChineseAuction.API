using System.ComponentModel.DataAnnotations;
using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.DTO
{
    public class OrderDTO
    {
        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Draft;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "מזהה משתמש לא תקין")]
        public int userId { get; set; }
        [Required]
        public DateTime dateTime { get; set; }
        public List<OrderItemDTO> orders { get; set; } = new();
        [Range(0, int.MaxValue, ErrorMessage = "הכמות אינו יכול להיות שלילי")]
        public int TotalAmount { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "המחיר אינו יכול להיות שלילי")]
        public int TotalPrice { get; set; } 
    } 
    public class OrderItemDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]

        public GiftCategory Category { get; set; }
        [Range(1, 100, ErrorMessage = "כמות חייבת להיות בין 1 ל-100")]
        public int Amount { get; set; } = 1;
        [Range(0, 10000, ErrorMessage = "המחיר אינו תקין")]
        public int price { get; set; }
        public string? Image { get; set; }
    }
    public class AddGiftRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "מזהה הזמנה לא תקין")]
        public int OrderId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "מזהה מתנה לא תקין")]
        public int GiftId { get; set; }
        [Required]
        [Range(1, 50, ErrorMessage = "ניתן להוסיף בין 1 ל-50 פריטים בכל פעם")]
        public int Amount { get; set; }
    }
}
