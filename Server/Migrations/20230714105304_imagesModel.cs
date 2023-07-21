using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Migrations
{
    /// <summary>
    /// Images upload new migration
    /// </summary>
    public partial class ImagesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_ApplicationUserId",
                table: "Transaction");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b61805b4-1114-4710-b46f-a9048aa547cf");

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("e4fabb77-f241-4fbc-9bef-b301a515c22c"));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Transaction",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Room",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                column: "ConcurrencyStamp",
                value: "353d4dde-acc8-4d9a-b43e-d36fb04e8dbc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed230c85-26c2-41da-b251-d2d853de3b9b", "e5cab9e2-2871-4bca-845f-7ec49594933a", "Guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfc5d3ab-8bcf-4e34-9842-0f158cb226c5", "AQAAAAEAACcQAAAAEF9BB4DEpG0Cq7MQe1by+x/37d11KHq7EU4WzSQaR2LdpWw307bKoVmEWE/NAxaOGA==", "08fa8ff2-70a2-4bb5-aaee-f76636de9ad4" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                column: "ImageUrl",
                value: "imageurlstring");

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "ApplicationUserId", "ArrivalDate", "DepartureDate", "RoomId", "RoomPrice", "TotalSum", "TransactionDateTime" },
                values: new object[] { new Guid("ec807f42-5713-45c6-9aa7-920b736d3112"), "2d5168cc-2092-4eaa-b62a-95ee7d587951", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11223344-5566-7788-99aa-bbccddeeff00"), 1230.0, 23456.0, new DateTimeOffset(new DateTime(2023, 7, 14, 13, 53, 3, 635, DateTimeKind.Unspecified).AddTicks(2812), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Image_RoomId",
                table: "Image",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_ApplicationUserId",
                table: "Transaction",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_ApplicationUserId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed230c85-26c2-41da-b251-d2d853de3b9b");

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("ec807f42-5713-45c6-9aa7-920b736d3112"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Room");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Transaction",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                column: "ConcurrencyStamp",
                value: "40ba9434-3121-4465-8ca6-5bb7450a3351");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b61805b4-1114-4710-b46f-a9048aa547cf", "3d1d6c19-896f-4538-a9e3-eb2a0e2cd249", "Guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c154b6bc-5c5c-4b91-9815-e8f3fbef8625", "AQAAAAEAACcQAAAAEO7Aqu+EVWEpL5gSA5g6U8UEQPD0GxquqfjG6RlQLMQxY/OjJ9+HiQUIgUX6vO3Rlg==", "32a6b82b-eb86-4e98-a1f3-1348a52b3438" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "ApplicationUserId", "ArrivalDate", "DepartureDate", "RoomId", "RoomPrice", "TotalSum", "TransactionDateTime" },
                values: new object[] { new Guid("e4fabb77-f241-4fbc-9bef-b301a515c22c"), "2d5168cc-2092-4eaa-b62a-95ee7d587951", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11223344-5566-7788-99aa-bbccddeeff00"), 1230.0, 23456.0, new DateTimeOffset(new DateTime(2023, 3, 29, 11, 20, 17, 374, DateTimeKind.Unspecified).AddTicks(4914), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_ApplicationUserId",
                table: "Transaction",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
