using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Migrations
{
    public partial class newColumnToTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9932716e-8158-40c2-aef3-25ea6e45db0a");

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("4394c218-1b34-4826-b948-e2e7cdecb582"));

            migrationBuilder.RenameColumn(
                name: "Sum",
                table: "Transaction",
                newName: "TotalSum");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "723a2c3d-ea61-4a58-a5a6-76ac18e97e97");

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("31eb8912-e08c-4fea-8d4e-ca420e70bc5e"));

            migrationBuilder.RenameColumn(
                name: "TotalSum",
                table: "Transaction",
                newName: "Sum");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                column: "ConcurrencyStamp",
                value: "dc048426-2c06-4e47-b0bd-ea1c838bc238");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9932716e-8158-40c2-aef3-25ea6e45db0a", "32cb3b7e-92b0-479c-8a3a-5d96f8b7452c", "Guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa5999e4-ab3e-4cbb-acce-30da4fa2f072", "AQAAAAEAACcQAAAAEBWMw87+fTICiORbK76VJGLwBpWhKL9cn/jnCxfD/+RGfil8ac8E6WZS6vzXprq4dQ==", "cebe2df2-ab58-4832-81a2-a41159c46bb9" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "ApplicationUserId", "ArrivalDate", "DepartureDate", "RoomId", "Sum", "TransactionDateTime" },
                values: new object[] { new Guid("4394c218-1b34-4826-b948-e2e7cdecb582"), "2d5168cc-2092-4eaa-b62a-95ee7d587951", new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11223344-5566-7788-99aa-bbccddeeff00"), 23456.0, new DateTimeOffset(new DateTime(2022, 12, 27, 1, 12, 30, 842, DateTimeKind.Unspecified).AddTicks(2810), new TimeSpan(0, 1, 0, 0, 0)) });
        }
    }
}
