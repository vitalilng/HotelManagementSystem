using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Migrations
{
    public partial class AddSoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cba4a459-67e1-446c-9f93-2c0fb734b9f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1a30582-a453-43af-8158-c5c6229d48f1");

            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d5168cc-2092-4eaa-b62a-95ee7d587951", "df084b9a-7a35-4f93-9294-1dac78b859cb", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f90b09cc-4574-4925-a692-31b4c8eeb249", "d776635a-dc4d-4c5f-b36f-a0b706fa80ae", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordConfirm", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SoftDeleted", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2d5168cc-2092-4eaa-b62a-95ee7d587951", 0, "f53f4b38-a9b7-48f7-9c70-03467d8e6811", null, "administrator@page.com", true, null, false, null, "administrator@page.com", "ADMIN", null, null, "AQAAAAEAACcQAAAAELdjYjPCoz72o1pDE3PX2Cn1Flnhb9ivzRxJEmYVLuiSxip1K9m3LGJzt8rgfyWoVw==", null, false, "e13d36de-8de3-4614-b45e-e01816b506b8", false, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2d5168cc-2092-4eaa-b62a-95ee7d587951", "2d5168cc-2092-4eaa-b62a-95ee7d587951" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f90b09cc-4574-4925-a692-31b4c8eeb249");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d5168cc-2092-4eaa-b62a-95ee7d587951", "2d5168cc-2092-4eaa-b62a-95ee7d587951" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951");

            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cba4a459-67e1-446c-9f93-2c0fb734b9f3", "21bdab0f-57ee-4541-8348-eb79246156c4", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1a30582-a453-43af-8158-c5c6229d48f1", "6f28c6fd-2e85-443b-8600-341d07a04a9e", "Administrator", "ADMINISTRATOR" });
        }
    }
}
