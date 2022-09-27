using HotelManagementSystem.Shared.Models;

namespace HotelManagementSystem.Client.Services
{
    public interface IAuthService
    {
        Task Login(LoginRequest loginRequest);
        Task Register(RegistrationRequest registrationRequest);
        Task Logout();
        Task<CurrentUser> CurrentUserInfo();
    }
}
