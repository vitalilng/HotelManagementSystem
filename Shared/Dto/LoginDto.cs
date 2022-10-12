using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Shared.Dto
{
    public class LoginDto
    {
        [Required]
        [Display(Name = "UserName")]
        public string? UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string? Password { get; set; }
        [Display(Name = "Remembe Me?")]
        public bool RememberMe { get; set; }
    }
}
