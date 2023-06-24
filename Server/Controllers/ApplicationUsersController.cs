using HotelManagementSystem.Server.Extensions;
using HotelManagementSystem.Server.Service.Contracts;
using HotelManagementSystem.Shared.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Server.Controllers
{
    /// <summary>
    /// Controller for application users
    /// </summary>
    [Route("api/guestusers")]
    [ApiController]
    public class ApplicationUsersController : ApiControllerBase
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
        /// Get all users. We extract the result from the service layer and cast the baseResult to the
        /// specific ApiOkResponse type, and use the Result property to extract our required result
        /// </summary>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var baseResult = _serviceManager.ApplicationUserService.GetApplicationUsers();
            var users = baseResult.GetResult<IEnumerable<UserDetailsDto>>();
            return Ok(users);
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        [HttpGet("{userId}", Name ="ApplicationUserById")]
        public IActionResult GetApplicationUser(string userId)
        {
            //extract the user from the service layer
            var baseResult = _serviceManager.ApplicationUserService.GetApplicationUser(userId);

            //check if the result is succesfull, if not return the result of 
            //ProcessError method
            if (!baseResult.Success)
            {
                return ProcessError(baseResult);
            }

            var user = baseResult.GetResult<UserDetailsDto>();
            return Ok(user);
        }

        /// <summary>
        /// Create Guest user
        /// </summary>
        /// <param name="userDataForCreation"></param>
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
