using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class AddEntitiesMatchMatchResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeam = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    AwayTeam = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "date", nullable: false),
                    Stadium = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_Matches_Stadiums_Stadium",
                        column: x => x.Stadium,
                        principalTable: "Stadiums",
                        principalColumn: "StadiumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeam",
                        column: x => x.AwayTeam,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeam",
                        column: x => x.HomeTeam,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResultsOfMatches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamScore = table.Column<int>(type: "int", nullable: false),
                    HomeTeamScore = table.Column<int>(type: "int", nullable: false),
                    MatchWinnerId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    MatchLoserId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    OvertimesCount = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultsOfMatches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_ResultsOfMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultsOfMatches_Teams_MatchLoserId",
                        column: x => x.MatchLoserId,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultsOfMatches_Teams_MatchWinnerId",
                        column: x => x.MatchWinnerId,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeam",
                table: "Matches",
                column: "AwayTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeam",
                table: "Matches",
                column: "HomeTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Stadium",
                table: "Matches",
                column: "Stadium");

            migrationBuilder.CreateIndex(
                name: "IX_ResultsOfMatches_MatchLoserId",
                table: "ResultsOfMatches",
                column: "MatchLoserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultsOfMatches_MatchWinnerId",
                table: "ResultsOfMatches",
                column: "MatchWinnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultsOfMatches");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
