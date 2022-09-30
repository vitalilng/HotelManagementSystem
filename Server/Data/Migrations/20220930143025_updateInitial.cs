using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Migrations
{
    public partial class updateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ef0b342-ded6-415f-a280-9af7ca934e88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b6182ba-6a32-4941-9a9f-d7a40c6a72fa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29734f05-aca6-43f8-8c5d-dc5833a453a8", "a2644e81-4839-4301-95d0-a5db5e4528e3", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85f2d618-63bc-4c03-84cb-c41a2c447c60", "fd57a600-db46-487d-aaad-c15a6665d248", "Guest", "GUEST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29734f05-aca6-43f8-8c5d-dc5833a453a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85f2d618-63bc-4c03-84cb-c41a2c447c60");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ef0b342-ded6-415f-a280-9af7ca934e88", "3109bbc6-662c-4fe6-b73e-cb21e2be20a9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b6182ba-6a32-4941-9a9f-d7a40c6a72fa", "3bf97538-52e0-4ddf-b9d3-77fdbd0a27c6", "Guest", "GUEST" });
        }
    }
}
