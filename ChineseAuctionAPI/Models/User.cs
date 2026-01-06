using System.ComponentModel.DataAnnotations;

namespace ChineseAuctionAPI.Models
{
    public enum Role
    {
        user,
        Manager
    }
    public class User
    {
        [Key]
        public int userId { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "תעודת זהות חייבת להכיל 9 ספרות")]
        public string Identity { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "סיסמה היא שדה חובה")]
        [MinLength(6, ErrorMessage = "הסיסמה חייבת להכיל לפחות 6 תווים")]
        public string password { get; set; }
        [Required(ErrorMessage = "כתובת אימייל היא שדה חובה")]
        [EmailAddress(ErrorMessage = "כתובת אימייל לא תקינה")]
        public string? Email { get; set; }
        [Required]
        [Phone]
        public string PhonNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        [Required]
        public Role role { get; set; } = Role.user;
        public virtual ICollection<Order> Orders { get; set; } 
        public ICollection<Card> cards { get; set; } 
    }
}
