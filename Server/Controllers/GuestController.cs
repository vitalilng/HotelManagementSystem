﻿using HotelManagementSystem.Server.Data;
using HotelManagementSystem.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class GuestController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GuestController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGuests()
        {
            List<Guest> guests = await _applicationDbContext.Guests.ToListAsync();
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid guestId)
        {
            Guest? guest = await _applicationDbContext.Guests.FirstOrDefaultAsync(a => a.Id == guestId);
            return Ok(guest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest(Guest guest)
        {
            _applicationDbContext.Add(guest);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(guest.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGuest(Guest guest)
        {
            _applicationDbContext.Entry(guest).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(Guid guestId)
        {
            var guest = new Guest { Id = guestId };
            _applicationDbContext.Remove(guest);
            await _applicationDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}