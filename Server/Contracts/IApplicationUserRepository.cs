using HotelManagementSystem.Server.Models;

namespace HotelManagementSystem.Server.Contracts
{
    /// <summary>
    /// Application User Interface
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
    }
}
