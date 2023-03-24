using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Migrations
{
    public partial class UpdatesAndChangesController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82dbaace-5519-4092-97a5-038bb71e5925");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Room",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sum = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transaction_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Room_ApplicationUserId",
                table: "Room",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ApplicationUserId",
                table: "Transaction",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_RoomId",
                table: "Transaction",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_AspNetUsers_ApplicationUserId",
                table: "Room",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_AspNetUsers_ApplicationUserId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Room_ApplicationUserId",
                table: "Room");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a1a00b6-0935-4a5e-8239-b966e29ec0f5");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Room");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sum = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                column: "ConcurrencyStamp",
                value: "d1de6c06-5fe0-4210-bc3f-038e90bf3174");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82dbaace-5519-4092-97a5-038bb71e5925", "3d61449f-c33c-4d4e-a714-038980a3f07f", "Guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63a89004-6e49-4e43-9b2a-e0fa7b83d61d", "AQAAAAEAACcQAAAAEHsp4VZjn41g27yD0QrnuXvVUSTUG/LaAG2egtkBcw0uvEWr/u3GM9Dn//Xh3b42VQ==", "59c2d981-ea2d-43c8-90b9-b70d21d4f3ba" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "ApplicationUserId", "BookingPeriod", "RoomId", "Sum" },
                values: new object[] { new Guid("eccb9cb9-f482-4990-93b2-94f8a9dd1729"), "2d5168cc-2092-4eaa-b62a-95ee7d587951", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11223344-5566-7788-99aa-bbccddeeff00"), 23456.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ApplicationUserId",
                table: "Transactions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RoomId",
                table: "Transactions",
                column: "RoomId");
        }
    }
}
