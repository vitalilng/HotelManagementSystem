using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Migrations
{
    public partial class newTransactionField : Migration
    {
        /// <summary>
        /// Up method
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "723a2c3d-ea61-4a58-a5a6-76ac18e97e97");

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("31eb8912-e08c-4fea-8d4e-ca420e70bc5e"));

            migrationBuilder.AddColumn<double>(
                name: "RoomPrice",
                table: "Transaction",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                column: "ConcurrencyStamp",
                value: "f3d5fa14-cc42-4a48-be9d-c5825b047064");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a9512433-613d-46a3-b273-98ea7a33c7e9", "ff5062ea-5857-453c-a5a9-197aa939662a", "Guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87501fcc-e4e8-4ff2-abc0-c0fa39e9d520", "AQAAAAEAACcQAAAAECPNfnMpXWkwrffaXm6jSQIGDoQl1IhZQwNQoKQpBxrlzwmt5mZVDrQQ5VCmmATV0w==", "2799986e-0b73-4029-9e95-ee035dc51bfe" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "ApplicationUserId", "ArrivalDate", "DepartureDate", "RoomId", "RoomPrice", "TotalSum", "TransactionDateTime" },
                values: new object[] { new Guid("3c7631e3-dc7e-472e-9a14-7a7a24b9b40c"), "2d5168cc-2092-4eaa-b62a-95ee7d587951", new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11223344-5566-7788-99aa-bbccddeeff00"), 0.0, 23456.0, new DateTimeOffset(new DateTime(2023, 3, 28, 22, 28, 48, 968, DateTimeKind.Unspecified).AddTicks(7723), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        /// <summary>
        /// Down method
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9512433-613d-46a3-b273-98ea7a33c7e9");

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("3c7631e3-dc7e-472e-9a14-7a7a24b9b40c"));

            migrationBuilder.DropColumn(
                name: "RoomPrice",
                table: "Transaction");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                column: "ConcurrencyStamp",
                value: "e9d768cb-858e-4bd2-ad1a-edda69771923");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "723a2c3d-ea61-4a58-a5a6-76ac18e97e97", "26803bc2-0a3e-4eae-a64e-88f131113ea4", "Guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8eec910a-2372-443b-b268-9e7c205bc619", "AQAAAAEAACcQAAAAEPfmuuKjiDDu4KMnzLpwsiqwE/GIlPTvKXLNwR0BvJIiUth2BVsXPLRdR80gNnrlEw==", "d306fde2-699d-468e-9429-540678b1eeb4" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "ApplicationUserId", "ArrivalDate", "DepartureDate", "RoomId", "TotalSum", "TransactionDateTime" },
                values: new object[] { new Guid("31eb8912-e08c-4fea-8d4e-ca420e70bc5e"), "2d5168cc-2092-4eaa-b62a-95ee7d587951", new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11223344-5566-7788-99aa-bbccddeeff00"), 23456.0, new DateTimeOffset(new DateTime(2023, 1, 2, 16, 1, 23, 649, DateTimeKind.Unspecified).AddTicks(334), new TimeSpan(0, 2, 0, 0, 0)) });
        }
    }
}
