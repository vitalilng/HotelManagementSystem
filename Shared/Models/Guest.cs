using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Shared.Models
{
    public class Guest : BaseEntity
    {
        public string? FullName { get; set; }
        public string? Username { get; set; }        
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
    }
}