using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetRedLineAG.Migrations
{
    public partial class newtry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Entreprise",
                columns: new[] { "EntrepriseId", "CommentsEntreprise", "EmailEntreprise", "LinkEntreprise", "PersonId", "TelEntreprise", "TitleEntreprise" },
                values: new object[] { 1, null, null, null, null, null, "Non renseigné" });

            migrationBuilder.InsertData(
                table: "Statut",
                columns: new[] { "StatutId", "TitleStatut" },
                values: new object[] { 1, "Non renseigné" });

            migrationBuilder.InsertData(
                table: "Application",
                columns: new[] { "ApplicationId", "CommentsApplication", "EntrepriseId", "ExternalLinkApplication", "StatusApplication", "TimeApplication", "TitleApplication" },
                values: new object[] { 1, null, 1, null, null, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Non renseigné" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "ApplicationId", "CommentsPerson", "EmailPerson", "EntrepriseId", "FirstNamePerson", "LastNamePerson", "PersonSentModelId", "StatutId", "TelPerson" },
                values: new object[] { 1, 1, null, null, 1, null, "Non renseigné", null, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Application",
                keyColumn: "ApplicationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Entreprise",
                keyColumn: "EntrepriseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statut",
                keyColumn: "StatutId",
                keyValue: 1);
        }
    }
}
