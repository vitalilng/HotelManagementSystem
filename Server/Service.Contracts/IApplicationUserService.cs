﻿using HotelManagementSystem.Server.Models;
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
        /// <returns></returns>
        IEnumerable<UserDetailsDto> GetApplicationUsers();

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserDetailsDto GetApplicationUser(string userId);

        /// <summary>
        /// Create application guest user
        /// </summary>
        /// <param name="userCreationDataToBeDisplayed"></param>
        /// <returns></returns>
        UserDetailsDto CreateApplicationUser(UserDataForCreationDto userCreationDataToBeDisplayed);

        /// <summary>
        /// Delete guest user from db
        /// </summary>
        /// <param name="userId"></param>
        void DeleteApplicationUser(string userId);

        /// <summary>
        /// Update guest user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userUpdateDataToBeDisplayed"></param>
        void UpdateApplicationUser(string userId, UserDataForUpdateDto userUpdateDataToBeDisplayed);

        /// <summary>
        /// Patch guest user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        (UserDataForUpdateDto userDataForUpdate, ApplicationUser applicationUser) GetApplicationUserForPatch(string userId);

        /// <summary>
        /// Save patch modification
        /// </summary>
        /// <param name="userDataForPatch"></param>
        /// <param name="applicationUser"></param>
        void SaveChangesForPatch(UserDataForUpdateDto userDataForPatch, ApplicationUser applicationUser);
    }
}
