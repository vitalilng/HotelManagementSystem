using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    public partial class changesToTransactionModel : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a1a00b6-0935-4a5e-8239-b966e29ec0f5");

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("14dd857c-6e7b-48bd-a25c-023ad0d7e794"));

            migrationBuilder.RenameColumn(
                name: "BookingPeriod",
                table: "Transaction",
                newName: "DepartureDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TransactionDateTime",
                table: "Transaction",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9932716e-8158-40c2-aef3-25ea6e45db0a");

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("4394c218-1b34-4826-b948-e2e7cdecb582"));

            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TransactionDateTime",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "DepartureDate",
                table: "Transaction",
                newName: "BookingPeriod");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                column: "ConcurrencyStamp",
                value: "9cd82594-00e2-42d8-93fd-4b79e6b2b1a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a1a00b6-0935-4a5e-8239-b966e29ec0f5", "9b46e54d-04a4-4feb-8581-0cc1bf2aa974", "Guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f707d859-de97-4eee-9e5d-13f6c55c2373", "AQAAAAEAACcQAAAAEH3NRCCkNunHrsnT4U62Gvdckk6g+G7b/jp7o3+WQigw8IN017R80mIAILTm8UGXFw==", "2536299f-d5fa-4fd3-a251-858aff550c06" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "ApplicationUserId", "BookingPeriod", "RoomId", "Sum" },
                values: new object[] { new Guid("14dd857c-6e7b-48bd-a25c-023ad0d7e794"), "2d5168cc-2092-4eaa-b62a-95ee7d587951", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11223344-5566-7788-99aa-bbccddeeff00"), 23456.0 });
        }
    }
}
