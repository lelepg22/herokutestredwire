using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetRedLineAG.Migrations
{
    public partial class ibelieveless : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Application_ApplicationId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_ApplicationId",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Person_ApplicationId",
                table: "Person",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Application_ApplicationId",
                table: "Person",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
