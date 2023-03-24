using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagementSystem.Server.Configuration
{
    /// <summary>
    /// Role Configuration
    /// </summary>
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                //new IdentityRole
                //{
                //    Name = "Administrator",
                //    NormalizedName = "ADMINISTRATOR"
                //},
                new IdentityRole
                {
                    Name = "Guest",
                    NormalizedName = "GUEST"
                });
        }
    }
}
