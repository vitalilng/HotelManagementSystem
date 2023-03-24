using HotelManagementSystem.Server.Models;

namespace HotelManagementSystem.Server.Contracts
{
    /// <summary>
    /// ApplicationUser Repository
    /// </summary>
    public interface IApplicationUserRepository
    {
        /// <summary>
        /// Return all guest users
        /// </summary>
        /// <returns></returns>
        IEnumerable<ApplicationUser> GetApplicationUsers();

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ApplicationUser GetApplicationUser(string userId);

        /// <summary>
        /// Add new Guest user
        /// </summary>
        /// <param name="user"></param>
        void CreateApplicationUser(ApplicationUser user);

        /// <summary>
        /// Delete a guest user from DB
        /// </summary>
        /// <param name="user"></param>
        void DeleteApplicationUser(ApplicationUser user);

        /// <summary>
        /// Update guest user
        /// </summary>
        /// <param name="user"></param>
        void UpdateApplicationUser(ApplicationUser user);
    }
}
