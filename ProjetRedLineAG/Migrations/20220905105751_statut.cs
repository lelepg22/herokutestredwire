using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetRedLineAG.Migrations
{
    public partial class statut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Statut_StatutId",
                table: "Person");

            migrationBuilder.UpdateData(
                table: "Application",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "TimeApplication",
                value: new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Statut_StatutId",
                table: "Person",
                column: "StatutId",
                principalTable: "Statut",
                principalColumn: "StatutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Statut_StatutId",
                table: "Person");

            migrationBuilder.UpdateData(
                table: "Application",
                keyColumn: "ApplicationId",
                keyValue: 1,
                column: "TimeApplication",
                value: new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Statut_StatutId",
                table: "Person",
                column: "StatutId",
                principalTable: "Statut",
                principalColumn: "StatutId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
