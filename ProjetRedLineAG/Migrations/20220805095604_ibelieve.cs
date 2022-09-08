using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetRedLineAG.Migrations
{
    public partial class ibelieve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Application_ApplicationId",
                table: "Person");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Application_ApplicationId",
                table: "Person",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Application_ApplicationId",
                table: "Person");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Application_ApplicationId",
                table: "Person",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "ApplicationId");
        }
    }
}
