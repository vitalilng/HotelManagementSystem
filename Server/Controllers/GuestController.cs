using Duende.IdentityServer.Models;
using HotelManagementSystem.Server.Data;
using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelManagementSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class GuestController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public GuestController(ApplicationDbContext applicationDbContext,
                               UserManager<ApplicationUser> userManager                               )
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));            
        }

        [HttpGet]
        public IActionResult GetAllGuests()
        {
            IQueryable<ApplicationUser> applicationUsers = _userManager.Users;
            return Ok(applicationUsers);
        }

        [HttpGet("{guestId}")]
        public async Task<IActionResult> Get(string guestId)
        {
            var applicationUser = await _userManager.FindByIdAsync(guestId);
            if (applicationUser is null)
            {
                return NotFound();
            }
            return Ok(applicationUser);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest(RegistrationDto guestUser)
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
                    return RedirectToPage("guest");
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

        [HttpPut]
        public async Task<IActionResult> UpdateGuest([FromBody]RegistrationDto guestUser)
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
                    return RedirectToPage("guest");
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

        [HttpDelete("{guestId}")]
        public async Task<IActionResult> DeleteGuest(string guestId)
        {
            var applicationUser = await _userManager.FindByIdAsync(guestId);
            if (applicationUser == null)
            {
                throw new ArgumentNullException("User not found", nameof(ApplicationUser));
            }
            await _userManager.DeleteAsync(applicationUser);
            return NoContent();
        }
    }
}