using HotelManagementSystem.Shared.Dto;

namespace HotelManagementSystem.Client.Services
{
    public interface IAuthService
    {
        Task Login(LoginDto loginRequest);
        Task Register(RegistrationDto registrationRequest);
        Task Logout();
        Task<CurrentUserDto> CurrentUserInfo();
    }
}
