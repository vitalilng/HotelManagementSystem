﻿using HotelManagementSystem.Shared.Dto;

namespace HotelManagementSystem.Client.Services
{
    public interface IGuestService
    {
        //IQueryable<ApplicationUser> GetGuests();
        Task GetById(string guestId);
        Task CreateGuest(RegistrationDto registrationDto);
        Task UpdateGuest(RegistrationDto registrationDto);
        Task DeleteGuest(string guestId);
    }
}
