using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApi.Migrations
{
    public partial class seederaddmoredata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Balance", "CreatedAt", "DeletedAt", "NumberAccess", "Pin", "UserId", "isDeleted" },
                values: new object[,]
                {
                    { 1, 500000, new DateTime(2021, 10, 31, 11, 18, 16, 558, DateTimeKind.Local).AddTicks(7540), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "xxx123", "123456", 1, false },
                    { 2, 700000, new DateTime(2021, 10, 31, 11, 18, 16, 558, DateTimeKind.Local).AddTicks(9085), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "xxx456", "654321", 2, false }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 31, 11, 18, 16, 552, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 31, 11, 18, 16, 555, DateTimeKind.Local).AddTicks(960));

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CreatedAt", "DeletedAt", "ReceiverId", "SenderId", "isDeleted" },
                values: new object[] { 1, 100000, new DateTime(2021, 10, 31, 11, 18, 16, 559, DateTimeKind.Local).AddTicks(4568), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, false });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CreatedAt", "DeletedAt", "ReceiverId", "SenderId", "isDeleted" },
                values: new object[] { 2, 50000, new DateTime(2021, 10, 31, 11, 18, 16, 559, DateTimeKind.Local).AddTicks(9251), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 31, 11, 6, 52, 920, DateTimeKind.Local).AddTicks(9101));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 31, 11, 6, 52, 922, DateTimeKind.Local).AddTicks(9524));
        }
    }
}
