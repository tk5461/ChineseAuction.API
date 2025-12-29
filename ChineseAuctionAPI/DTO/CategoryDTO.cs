using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.DTO
{
    public class CategoryDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
