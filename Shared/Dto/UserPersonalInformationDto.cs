using HotelManagementSystem.Shared.Dto;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Shared.Models
{
    public class UserPersonalInformationDto: BaseEntityDto
    {
        [Required]
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }
        
        [Required]
        [Display(Name = "UserName")]
        public string? UserName { get; set; }
        
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Not a valid Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        
        [Required]
        [Display(Name = "Country")]
        public string? Country { get; set; }
        
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}