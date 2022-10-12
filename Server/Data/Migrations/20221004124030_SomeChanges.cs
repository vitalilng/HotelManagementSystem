using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Migrations
{
    public partial class SomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab2fa0a5-5d81-4dab-82f8-e1b2e351ee38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc373e4b-2036-4a97-8f94-efe83a31325e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cba4a459-67e1-446c-9f93-2c0fb734b9f3", "21bdab0f-57ee-4541-8348-eb79246156c4", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1a30582-a453-43af-8158-c5c6229d48f1", "6f28c6fd-2e85-443b-8600-341d07a04a9e", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cba4a459-67e1-446c-9f93-2c0fb734b9f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1a30582-a453-43af-8158-c5c6229d48f1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab2fa0a5-5d81-4dab-82f8-e1b2e351ee38", "141fb35a-fa4a-4b41-940a-44604e3024de", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc373e4b-2036-4a97-8f94-efe83a31325e", "8e6964b9-f813-4b38-8317-5e2aed7b5d78", "Guest", "GUEST" });
        }
    }
}
