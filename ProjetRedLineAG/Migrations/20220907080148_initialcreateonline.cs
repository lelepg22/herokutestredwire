using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetRedLineAG.Migrations
{
    public partial class initialcreateonline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Application",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "TimeApplication",
                value: new DateTime(2022, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Application",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "TimeApplication",
                value: new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
