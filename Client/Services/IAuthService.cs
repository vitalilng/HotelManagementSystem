using HotelManagementSystem.Shared.Dto;

namespace HotelManagementSystem.Client.Services
{
    public interface IAuthService
    {
        Task Login(LoginDto loginRequest);
        Task Register(UserDetailsDto registrationRequest);
        Task Logout();
        Task<CurrentUserDto> CurrentUserInfo();
    }
}
