using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Data;
using HotelManagementSystem.Server.Models;
using System.Diagnostics.CodeAnalysis;

namespace HotelManagementSystem.Server.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationDbContext"></param>
        public ApplicationUserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        /// <summary>
        /// Find all guest user ordered by username into a list
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public IEnumerable<ApplicationUser> GetAllGuestUsers(bool trackChanges) => 
            FindAll(trackChanges)
            .OrderBy(c => c.UserName)
            .ToList();

        /// <summary>
        /// Get user by
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>

        public ApplicationUser GetApplicationUser(string userId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(userId), trackChanges)
            .SingleOrDefault();
    }
}
