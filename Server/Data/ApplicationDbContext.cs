using HotelManagementSystem.Server.Configuration;
using HotelManagementSystem.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Server.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            
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

            // Application User relationship to Transactions table
            modelBuilder.Entity<ApplicationUser>()                
                .HasMany(b => b.Transactions)
                .WithOne(b => b.ApplicationUser);

            // Room relationship to Transactions table
            modelBuilder.Entity<Room>()
                .HasMany(b => b.Transactions)
                .WithOne(b => b.Room);
            
            Guid g = new ("11223344-5566-7788-99AA-BBCCDDEEFF00");

            modelBuilder.Entity<Room>()
                .HasData(new Room()
                {
                    Id = g,
                    RoomType = "Single",
                    RoomSize = "21",
                    NrOfBedsAndSizes = "Single Bed(1.60 x 2.00)",
                    RoomOptions = "FreeWifi, TV, Safe, Karaoke",
                    MaxPersonsAllowed = "2",
                    Availability = "Available",
                    Description = "Room Description",
                    Price = 123
                });

            modelBuilder.Entity<Transaction>()                
                .HasData(new Transaction()
                {
                    Id = Guid.NewGuid(),
                    ApplicationUserId = adminID,
                    RoomId = g,
                    ArrivalDate = new DateTime(2022,12,20),
                    DepartureDate = new DateTime(2022, 12, 27),
                    TotalSum = 23456,
                    TransactionDateTime = DateTimeOffset.Now,
                });
        }
    }
}