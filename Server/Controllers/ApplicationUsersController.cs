using HotelManagementSystem.Server.Service.Contracts;
using HotelManagementSystem.Shared.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Server.Controllers
{
    /// <summary>
    /// Controller for all guest and admin users
    /// </summary>
    [Route("api/guestusers")]
    [ApiController]
    public class ApplicationUsersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        /// <summary>
        /// inject Iservice manager
        /// </summary>
        /// <param name="serviceManager"></param>
        public ApplicationUsersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        /// <summary>
        /// Get all guest users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetGuests()
        {
            var guests = _serviceManager.ApplicationUserService.GetApplicationUsers();
            return Ok(guests);
        }

        /// <summary>
        /// Get guest user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}", Name ="ApplicationUserById")]
        public IActionResult GetApplicationUser(string userId)
        {
            var applicationUser = _serviceManager.ApplicationUserService.GetApplicationUser(userId);
            return Ok(applicationUser);
        }

        /// <summary>
        /// Create Guest user
        /// </summary>
        /// <param name="userDataForCreation"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateGuestUser([FromBody] UserDataForCreationDto userDataForCreation)
        {
            if (userDataForCreation is null)
            {
                return BadRequest("UserDataForCreationDto object is null");
            }
            var createdGuestUser = _serviceManager.ApplicationUserService.CreateApplicationUser(userDataForCreation);

            return CreatedAtRoute("ApplicationUserById", new { userId = createdGuestUser.Id }, createdGuestUser);
        }

        /// <summary>
        /// Delete guest user from db
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public IActionResult DeleteGuestUser(string userId)
        {
            _serviceManager.ApplicationUserService.DeleteApplicationUser(userId);
            return NoContent();// return 204 No Content
        }

        /// <summary>
        /// Update guest user by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userDataForUpdate"></param>
        /// <returns></returns>
        [HttpPut("{userId}")]
        public IActionResult UpdateGuestUser(string userId, [FromBody] UserDataForUpdateDto userDataForUpdate)
        {
            if (userDataForUpdate is null)
            {
                return BadRequest("UserDataForUpdateDto is null");
            }
            _serviceManager.ApplicationUserService.UpdateApplicationUser(userId, userDataForUpdate);
            return NoContent();
        }

        /// <summary>
        /// Partial Update Application User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{userId}")]
        public IActionResult PartialUpdateApplicationUser(string userId,
                                                          [FromBody] JsonPatchDocument<UserDataForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("PatchDoc object sent from client is null.");
            }
            var result = _serviceManager.ApplicationUserService.GetApplicationUserForPatch(userId);
            patchDoc.ApplyTo(result.userDataForUpdate);
            _serviceManager.ApplicationUserService.SaveChangesForPatch(result.userDataForUpdate, result.applicationUser);
            return NoContent();
        }
    }
}
