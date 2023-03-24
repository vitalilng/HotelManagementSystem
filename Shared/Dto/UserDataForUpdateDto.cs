using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Shared.Dto
{
    public class UserDataForUpdateDto
    {
        [Required]
        [Display(Name = "Full Name")]
        [StringLength(15)]
        public string? FullName { get; set; }
        
        [Required]
        [Display(Name = "UserName")]
        [StringLength(10)]
        public string? UserName { get; set; }
        
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Not a valid Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string? PhoneNumber { get; set; }
        
        [Required]
        [Display(Name = "Country")]        
        public string? Country { get; set; }
        
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }
    }
}