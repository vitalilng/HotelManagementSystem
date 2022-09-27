using HotelManagementSystem.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace HotelManagementSystem.Client.Services
{
    public class CustomStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthService _authService;
        private CurrentUser? _currentUser;
        public CustomStateProvider(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                CurrentUser userInfo = await GetCurrentUser();
                if (userInfo.IsAuthenticated)
                {
                    IEnumerable<Claim> claims = new[] { new Claim(ClaimTypes.Name, _currentUser.UserName) }
                    .Concat(_currentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server Authorization");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed" + ex.ToString());   
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        private async Task<CurrentUser> GetCurrentUser()
        {
            if (_currentUser != null && _currentUser.IsAuthenticated) return _currentUser;
            _currentUser = await _authService.CurrentUserInfo();
            return _currentUser;
        }

        public async Task Logout()
        {
            await _authService.Logout();
            _currentUser = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Login(LoginRequest loginParameters)
        {
            await _authService.Login(loginParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Register(RegistrationRequest registrationParameters)
        {
            await _authService.Register(registrationParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}