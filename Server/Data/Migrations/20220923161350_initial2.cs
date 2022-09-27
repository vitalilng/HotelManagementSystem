using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a90897f-5294-47ee-890d-ded75ca88b35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b564b23b-6bf2-49be-8e85-2250ba0b371b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22691013-7b23-43af-a09c-ca3fb62ee0d1", "306973de-0f6d-4acf-9fde-910fe2875cc1", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95b25ff6-1a87-4a5a-9193-1987b3d8ff19", "c28821e2-93e7-4b7f-8224-173edc6c8037", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22691013-7b23-43af-a09c-ca3fb62ee0d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95b25ff6-1a87-4a5a-9193-1987b3d8ff19");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a90897f-5294-47ee-890d-ded75ca88b35", "69b28ce0-e380-4afc-99df-889eaf51d425", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b564b23b-6bf2-49be-8e85-2250ba0b371b", "c845446b-34f7-4acc-8d8e-fd9c14f01494", "Guest", "GUEST" });
        }
    }
}
