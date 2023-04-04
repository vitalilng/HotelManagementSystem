using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Shared.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace HotelManagementSystem.Server.Controllers
{
    /// <summary>
    /// Guest controller
    /// </summary>
    [Route("api/guests")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class GuestController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// GuestController constructor with userManager DI
        /// </summary>
        /// <param name="userManager"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GuestController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        /// <summary>
        /// Gets all guest users
        /// </summary>
        /// <returns>The list of all guests</returns>
        [Route("")]
        [HttpGet]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetGuests()
        {
            IQueryable<ApplicationUser> applicationUsers = _userManager.Users.Where(u => u.UserName != "admin");
            return Ok(applicationUsers);
        }

        /// <summary>
        /// Get a guest by id
        /// </summary>
        /// <param name="guestId"></param>
        /// <returns>The guest by id</returns>
        [Route("{guestId}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string guestId)
        {
            var applicationUser = await _userManager.FindByIdAsync(guestId);

            if (applicationUser is null )
            {
                return NotFound();
            }
            return Ok(applicationUser);
        }

        /// <summary>
        /// Create a Guest
        /// </summary>
        /// <param name="guestUser"></param>
        /// <returns>The created guest user</returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateGuest(UserDetailsDto guestUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new()
                {
                    FullName = guestUser.FullName,
                    UserName = guestUser.UserName,
                    Email = guestUser.Email,
                    Country = guestUser.Country,
                    PhoneNumber = guestUser.PhoneNumber,
                    Password = guestUser.Password,
                    EmailConfirmed = true
                };

                IdentityResult identityResult = await _userManager.CreateAsync(applicationUser, guestUser.Password);
                if (identityResult.Succeeded)
                {
                    return RedirectToPage("guests");
                }
                else
                {
                    foreach (IdentityError error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return Ok(guestUser.Id);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update a Guest
        /// </summary>
        /// <param name="guestUser"></param>
        /// <returns>Updated guest data</returns>
        [HttpPut]
        [Route("{guestId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGuest([FromBody]UserDetailsDto guestUser)
        {
            var applicationUser = await _userManager.FindByIdAsync(guestUser.Id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            else
            {
                applicationUser.FullName = guestUser.FullName;
                applicationUser.UserName = guestUser.UserName;
                applicationUser.Email = guestUser.Email;
                applicationUser.Country = guestUser.Country;
                applicationUser.PhoneNumber = guestUser.PhoneNumber;
                applicationUser.Password = guestUser.Password;
                applicationUser.PasswordConfirm = guestUser.PasswordConfirm;
                applicationUser.EmailConfirmed = true;

                var result = await _userManager.UpdateAsync(applicationUser);

                if (result.Succeeded)
                {
                    return RedirectToPage("guests");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return Ok(guestUser);
        }

        /// <summary>
        /// Delete a Guest by id
        /// </summary>
        /// <param name="guestId">List without the deleted guest user</param>
        [HttpDelete]
        [Route("{guestId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteGuest(string guestId)
        {
            var applicationUser = await _userManager.FindByIdAsync(guestId);
            if (applicationUser == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(applicationUser);
            return NoContent();
        }
    }
}