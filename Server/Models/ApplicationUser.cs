using Microsoft.AspNetCore.Identity;

namespace HotelManagementSystem.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Country { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public bool SoftDeleted { get; set; }
    }
}