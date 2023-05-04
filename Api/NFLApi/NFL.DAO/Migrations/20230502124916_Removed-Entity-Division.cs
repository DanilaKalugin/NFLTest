using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class RemovedEntityDivision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Divisions_TeamDivision",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeamDivision",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamDivision",
                table: "Teams");

            migrationBuilder.AlterColumn<byte>(
                name: "ConferenceId",
                table: "Teams",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ConferenceId",
                table: "Teams",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Conferences_ConferenceId",
                table: "Teams",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "ConferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Conferences_ConferenceId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ConferenceId",
                table: "Teams");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "Teams",
                type: "int",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<byte>(
                name: "TeamDivision",
                table: "Teams",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    DivisionNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    ConferenceId = table.Column<byte>(type: "tinyint", nullable: false),
                    DivisionTitle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionNumber);
                    table.ForeignKey(
                        name: "FK_Divisions_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "ConferenceId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamDivision",
                table: "Teams",
                column: "TeamDivision");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ConferenceId",
                table: "Divisions",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Divisions_TeamDivision",
                table: "Teams",
                column: "TeamDivision",
                principalTable: "Divisions",
                principalColumn: "DivisionNumber");
        }
    }
}
