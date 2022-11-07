using HotelManagementSystem.Server.Service.Contracts;
using HotelManagementSystem.Shared.Dto;
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
            var guests = _serviceManager.ApplicationUserService.GetAllGuestUsers(trackChanges: false);
            return Ok(guests);
        }

        /// <summary>
        /// Get application user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}", Name ="ApplicationUserById")]
        public IActionResult GetApplicationUser(string userId)
        {
            var applicationUser = _serviceManager.ApplicationUserService.GetApplicationUser(userId, trackChanges: false);
            return Ok(applicationUser);
        }

        /// <summary>
        /// Create Application Guest user
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
            var createdGuestUser = _serviceManager.ApplicationUserService.CreateGuestUser(userDataForCreation);

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
            _serviceManager.ApplicationUserService.DeleteGuestUser(userId, trackChanges: false);
            return NoContent();// return 204 No Content
        }
    }
}
