using HotelManagementSystem.Server.Service.Contracts;
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
        [HttpGet("{userId}")]
        public IActionResult GetApplicationUser(string userId)
        {
            var applicationUser = _serviceManager.ApplicationUserService.GetApplicationUser(userId, trackChanges: false);
            return Ok(applicationUser);
        }

    }
}
