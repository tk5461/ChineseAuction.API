using System.ComponentModel.DataAnnotations;
using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.DTO
{
    public class User_DTO
    {
        public string Identity { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string? Email { get; set; }
        [Phone]
        public string PhonNumber { get; set; }
    } 
    public class LoginUserDTO
    {
        public string Identity { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string password { get; set; }

        [Phone]
        public string PhonNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
    public class DTOuserOrder
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public List<OrderDTO> orders { get; set; } = new();
    }
}
