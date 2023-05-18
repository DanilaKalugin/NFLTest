using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class AddedRelationNDConference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Conferences_ConferenceLevel",
                table: "Conferences",
                column: "ConferenceLevel");

            migrationBuilder.AddForeignKey(
                name: "FK_Conferences_NationalDivisions_ConferenceLevel",
                table: "Conferences",
                column: "ConferenceLevel",
                principalTable: "NationalDivisions",
                principalColumn: "DivisionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conferences_NationalDivisions_ConferenceLevel",
                table: "Conferences");

            migrationBuilder.DropIndex(
                name: "IX_Conferences_ConferenceLevel",
                table: "Conferences");
        }
    }
}
