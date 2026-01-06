using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.DTO
    {
        public class GiftDTO
        {
        [Required]
        [StringLength(100, ErrorMessage = "שם המתנה לא יכול לעלות על 100 תווים")]
        public string Name { get; set; } = string.Empty;
            public string? Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Range(1, 1000, ErrorMessage = "הכמות חייבת להיות לפחות 1")]
        public int Quantity { get; set; } = 1;
        [Range(0, 10000, ErrorMessage = "המחיר אינו יכול להיות שלילי")]

        public int Price { get; set; }
            public string? Image { get; set; }
        [Required]

        public int IdDonor { get; set; }
     }
}
public class GiftDTONew
{
    public int IdGift { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int NumOfBuyers { get; set; } 
}
