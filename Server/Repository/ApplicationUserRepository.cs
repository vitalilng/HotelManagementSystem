using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Data;
using HotelManagementSystem.Server.Models;

namespace HotelManagementSystem.Server.Repository
{
    /// <summary>
    /// Repository for database data
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
        /// <returns></returns>
        public IEnumerable<ApplicationUser> GetApplicationUsers() => 
            FindAll()
            .OrderBy(c => c.UserName)
            .ToList();

        /// <summary>
        /// Get user by
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ApplicationUser GetApplicationUser(string userId)
        {
            var result = new ApplicationUser() ;
            if (userId is not null)
            {
                result = FindByCondition(c => c.Id.Equals(userId)).SingleOrDefault();
            }
            return result?? throw new ArgumentNullException(nameof(userId));
        }

        /// <summary>
        /// Create new guest application user
        /// </summary>
        /// <param name="applicationUser"></param>
        public void CreateApplicationUser(ApplicationUser applicationUser) => Create(applicationUser);

        /// <summary>
        /// Delete guest user from db
        /// </summary>
        /// <param name="applicationUser"></param>
        public void DeleteApplicationUser(ApplicationUser applicationUser) => Delete(applicationUser);

        /// <summary>
        /// Update guest user
        /// </summary>
        /// <param name="applicationUser"></param>
        public void UpdateApplicationUser(ApplicationUser applicationUser) => Update(applicationUser);
       
    }
}
