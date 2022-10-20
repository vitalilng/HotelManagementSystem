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

            //SoftDelete implementation
            modelBuilder.Entity<ApplicationUser>().HasQueryFilter(q => !q.SoftDeleted);

            //creating and seeding admin user to DB
            const string adminID = "2d5168cc-2092-4eaa-b62a-95ee7d587951";
            const string roleId = adminID;

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = roleId,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                });

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<ApplicationUser>();

            //Seeding the Admin user to AspNetUsers table
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser()
                {
                    Id = adminID,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "administrator@page.com",
                    NormalizedEmail = "administrator@page.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!")
                });

            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = roleId,
                    UserId = adminID,
                });
        }
    }
}