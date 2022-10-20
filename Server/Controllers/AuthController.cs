using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace HotelManagementSystem.Learner.Server.Controllers
{
    /// <summary>
    /// Authorization Controller class
    /// </summary>
    [RoutePrefix("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        /// <summary>
        /// AuthorizationController constructor with userManager and signInManager dependency injected
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        /// <summary>
        /// Login a guest
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return BadRequest("User does not exist");
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!singInResult.Succeeded) return BadRequest("Invalid password");
            await _signInManager.SignInAsync(user, request.RememberMe);
            return Ok();
        }
        
        /// <summary>
        /// Register a new guest
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        public async Task<IActionResult> Register(RegistrationDto parameters)
        {
            var applicationUser = new ApplicationUser
            {
                FullName = parameters.FullName,
                UserName = parameters.UserName,
                Email = parameters.Email,
                PhoneNumber = parameters.PhoneNumber,
                Country = parameters.Country,
                Password = parameters.Password,
                PasswordConfirm = parameters.PasswordConfirm,
                EmailConfirmed = true

            };
            IdentityResult result = await _userManager.CreateAsync(applicationUser, parameters.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            }

            //Add all new users to Guest role
            await _userManager.AddToRoleAsync(applicationUser, "Guest");

            return await Login(new LoginDto
            {
                UserName = parameters.UserName,
                Password = parameters.Password
            });                        
        }

        /// <summary>
        /// Logout a user
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("logout")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        /// <summary>
        /// Get Current Information
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("curentuserinfo")]
        public CurrentUserDto CurrentUserInfo()
        {
            return new CurrentUserDto
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                Claims = User.Claims
                .ToDictionary(c => c.Type, c => c.Value)
            };
        }
    }
}