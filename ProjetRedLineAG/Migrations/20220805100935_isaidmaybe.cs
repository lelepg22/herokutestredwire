using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetRedLineAG.Migrations
{
    public partial class isaidmaybe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Application_ApplicationModelApplicationId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_ApplicationModelApplicationId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ApplicationModelApplicationId",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationModelApplicationId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_ApplicationModelApplicationId",
                table: "Person",
                column: "ApplicationModelApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Application_ApplicationModelApplicationId",
                table: "Person",
                column: "ApplicationModelApplicationId",
                principalTable: "Application",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
