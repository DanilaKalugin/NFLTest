using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class AddViewTeamStandings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW TeamStandings
AS
SELECT        dbo.Teams.TeamAbbreviation, COUNT(CASE WHEN MatchWinnerID = TeamAbbreviation THEN 1 ELSE NULL END) AS W, 
							COUNT(CASE WHEN MatchLoserID = TeamAbbreviation THEN 1 ELSE NULL END) AS L
FROM          
                         dbo.Matches INNER JOIN
                         dbo.ResultsOfMatches ON dbo.Matches.MatchID = dbo.ResultsOfMatches.MatchId RIGHT JOIN dbo.Teams ON dbo.Teams.TeamAbbreviation = dbo.Matches.AwayTeam OR dbo.Teams.TeamAbbreviation = dbo.Matches.HomeTeam 
GROUP BY dbo.Teams.TeamAbbreviation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW TeamStandings");
        }
    }
}
