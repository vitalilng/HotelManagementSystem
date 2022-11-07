using HotelManagementSystem.Shared.Dto;

namespace HotelManagementSystem.Client.Services
{
    public interface IGuestService
    {
        //IQueryable<ApplicationUser> GetGuests();
        Task GetById(string guestId);
        Task CreateGuest(UserDetailsDto registrationDto);
        Task UpdateGuest(UserDetailsDto registrationDto);
        Task DeleteGuest(string guestId);
    }
}
