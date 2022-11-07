using HotelManagementSystem.Shared.Dto;

namespace HotelManagementSystem.Server.Service.Contracts
{
    /// <summary>
    /// ApplicationUser service    
    /// 
    /// trackChanges parameter
    /// used to improve read-only query performance. When it’s set to false, we
    /// attach the AsNoTracking method to our query to inform EF Core that it doesn’t need to track changes
    /// for the required entities.This greatly improves the speed of a query
    /// </summary>
    public interface IApplicationUserService
    {
        /// <summary>
        /// Get All guest users
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        IEnumerable<UserDetailsDto> GetAllGuestUsers(bool trackChanges);
        
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        UserDetailsDto GetApplicationUser(string userId, bool trackChanges);

        /// <summary>
        /// Create application guest user
        /// </summary>
        /// <param name="userDataForCreation"></param>
        /// <returns></returns>
        UserDetailsDto CreateGuestUser(UserDataForCreationDto userDataForCreation);

        /// <summary>
        /// Delete guest user from db
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="trackChanges"></param>
        void DeleteGuestUser(string userId, bool trackChanges);

    }
}
