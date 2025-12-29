using System.ComponentModel.DataAnnotations;


namespace ChineseAuctionAPI.DTO
{
    public class User_DTO
    {
        public string Identity { get; set; } = string.Empty;
        [Required]
        public string First_Name { get; set; } = string.Empty;
        [Required]
        public string Last_Name { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string PhonNumber { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public class LoginResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public User_DTO User { get; set; } = new User_DTO();
    }

    public class LoginUserDTO
    {
        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "תעודת זהות חייבת להכיל 9 ספרות")]
        public string Identity { get; set; } = string.Empty;

        [Required]
        public string First_Name { get; set; } = string.Empty;

        [Required]
        public string Last_Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required, MinLength(6), DataType(DataType.Password)]
        public string password { get; set; } = string.Empty;

        [Phone]
        public string PhonNumber { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
    public class LoginRequestDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; } 

        [Required, MinLength(6), DataType(DataType.Password)]
        public string password { get; set; } 
    }
    public class DTOuserOrder
    {
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public List<OrderDTO> orders { get; set; } = new();
    }
}