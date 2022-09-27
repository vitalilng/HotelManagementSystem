using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Data.Migrations
{
    public partial class InitialRolesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c237f65-db0a-4466-a8b2-8a8d54f62531");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e082f749-9b96-422c-adbe-c9c5dd74f461");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19beccee-dff9-4ffb-a7db-213fd21519f6", "caebdec4-eac9-4ac9-9c59-da5bc0196dfa", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b9c0191-597f-4adf-8af4-d818172e4550", "958e22b7-1ff3-4de8-8887-9b00b2d908e9", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19beccee-dff9-4ffb-a7db-213fd21519f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b9c0191-597f-4adf-8af4-d818172e4550");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c237f65-db0a-4466-a8b2-8a8d54f62531", "20dd1b4f-93c6-49b9-aaef-9ab8a2e293ff", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e082f749-9b96-422c-adbe-c9c5dd74f461", "591f52ad-eaaf-4def-bd4c-6f62b61cd8c7", "Administrator", "ADMINISTRATOR" });
        }
    }
}
