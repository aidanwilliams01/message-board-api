using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBoardAPI.Migrations
{
    public partial class AddMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Group", "MessageDateTime", "Text", "UserName" },
                values: new object[] { 2, "Group 1", new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "example text", null });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Group", "MessageDateTime", "Text", "UserName" },
                values: new object[] { 3, "Group 2", new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "example text", null });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Group", "MessageDateTime", "Text", "UserName" },
                values: new object[] { 4, "Group 3", new DateTime(2022, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "example text", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4);
        }
    }
}
