using Microsoft.AspNetCore.Identity;

namespace HotelManagementSystem.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        //public string? UserName { get; set; }
        //public string? Email { get; set; }
        //public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
    }
}