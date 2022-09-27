using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Shared.Models
{
    public class RegistrationRequest
    {
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }        
        [Required]
        public string? Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        public string? PasswordConfirm { get; set; }
    }
}
