using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApi.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Fullname", "isDeleted" },
                values: new object[] { 1, new DateTime(2021, 10, 31, 11, 6, 52, 920, DateTimeKind.Local).AddTicks(9101), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hafiz Muhammad Fadli", false });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Fullname", "isDeleted" },
                values: new object[] { 2, new DateTime(2021, 10, 31, 11, 6, 52, 922, DateTimeKind.Local).AddTicks(9524), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzumaki Naruto", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
