using Microsoft.AspNetCore.Identity;

namespace HotelManagementSystem.Server.Models
{
    /// <summary>
    /// User class for CRUD user in database
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// user fullname
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// user country
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// user password
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// password confirmation field
        /// </summary>
        public string? PasswordConfirm { get; set; }

        /// <summary>
        /// Navigation property to transaction model
        /// </summary>
        public List<Transaction>? Transactions { get; set; }

        /// <summary>
        /// Rooms navigation property
        /// </summary>
        public List<Room>? Rooms { get; set; }
    }
}