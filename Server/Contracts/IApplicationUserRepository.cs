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
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        IEnumerable<ApplicationUser> GetAllGuestUsers(bool trackChanges);

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        ApplicationUser GetApplicationUser(string userId, bool trackChanges);

        /// <summary>
        /// Add new Guest user
        /// </summary>
        /// <param name="user"></param>
        void CreateGuestUser(ApplicationUser user);

        /// <summary>
        /// Delete a guest user from DB
        /// </summary>
        /// <param name="user"></param>
        void DeleteGuestUser(ApplicationUser user);
    }
}
