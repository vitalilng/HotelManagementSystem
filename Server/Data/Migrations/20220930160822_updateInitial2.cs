using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Migrations
{
    public partial class updateInitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "ac15976b-c83c-42a2-8534-cb0c000be11f", "8c67fb9f-14a0-4f79-8678-48607dabe934", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9b6b22c-1a55-443e-87e3-4ad75755d111", "ea30797e-a7fd-413d-952c-316b3de4f685", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac15976b-c83c-42a2-8534-cb0c000be11f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9b6b22c-1a55-443e-87e3-4ad75755d111");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29734f05-aca6-43f8-8c5d-dc5833a453a8", "a2644e81-4839-4301-95d0-a5db5e4528e3", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85f2d618-63bc-4c03-84cb-c41a2c447c60", "fd57a600-db46-487d-aaad-c15a6665d248", "Guest", "GUEST" });
        }
    }
}
