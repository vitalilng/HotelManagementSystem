using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Shared.Dto
{
    public class ChangePasswordDto
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Current Password")]
        public string? CurrentPassword { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string? NewPassword { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(NewPassword), ErrorMessage = "New Password and Confirm Password do not match!")]
        public string? ConfirmPassword { get; set; }
    }
}
