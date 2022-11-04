using HotelManagementSystem.Shared.Dto;

namespace HotelManagementSystem.Server.Service.Contracts
{
    /// <summary>
    /// ApplicationUser service
    /// </summary>
    public interface IApplicationUserService
    {
        /// <summary>
        /// Get All guest users
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        IEnumerable<RegistrationDto> GetAllGuestUsers(bool trackChanges);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        RegistrationDto GetApplicationUser(string userId, bool trackChanges);
    }
}
