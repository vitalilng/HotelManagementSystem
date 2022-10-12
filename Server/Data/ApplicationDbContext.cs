using HotelManagementSystem.Server.Configuration;
using HotelManagementSystem.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser()
                {
                    Id = "13fa3983-822d-4eb0-a19d-b7cdd6a4fb93",
                    UserName = "admin",
                    Email = "administrator@page.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!")
                });


            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = modelBuilder.Entity<IdentityRole>().GetType().Name,
                    UserId = "13fa3983-822d-4eb0-a19d-b7cdd6a4fb93"
                });
        }
    }
}