using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class ChangedTypeOfPropertiesTeamScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "HomeTeamScore",
                table: "ResultsOfMatches",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "AwayTeamScore",
                table: "ResultsOfMatches",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HomeTeamScore",
                table: "ResultsOfMatches",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "AwayTeamScore",
                table: "ResultsOfMatches",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }
    }
}
