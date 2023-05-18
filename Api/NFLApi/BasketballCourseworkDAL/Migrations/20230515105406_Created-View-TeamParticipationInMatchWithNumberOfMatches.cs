using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class CreatedViewTeamParticipationInMatchWithNumberOfMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW TeamParticipationInMatchWithNumberOfMatches 
AS 
select MatchId,
                 AwayTeam,
				 MatchDate,
				 IsPlayed,
                 row_number () over (partition by awayTeam order by MatchDate desc) as rn
            from TeamParticipationInMatches");

            migrationBuilder.Sql(@"CREATE VIEW LastMatchIdForTeamsWhoPlayedOnceOrMore
AS
SELECT AwayTeam, MatchId
from TeamParticipationInMatchWithNumberOfMatches
WHERE IsPlayed = 1 and rn = 1");

            migrationBuilder.Sql(@"ALTER VIEW IdForLastPlayedMatchForEveryTeam
                AS
           SELECT TeamAbbreviation, MatchId
from LastMatchIdForTeamsWhoPlayedOnceOrMore right JOIN teams on awayTeam = TeamAbbreviation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW IdForLastPlayedMatchForEveryTeam
                AS
            select AwayTeam, MatchId
    from (select MatchId,
                 AwayTeam,
				 MatchDate,
				 IsPlayed,
                 row_number () over (partition by awayTeam order by MatchDate desc) rn
            from TeamParticipationInMatches) as Matches
WHERE rn = 1 and IsPlayed = 1");

migrationBuilder.Sql(@"DROP VIEW LastMatchIdForTeamsWhoPlayedOnceOrMore");

migrationBuilder.Sql(@"DROP VIEW TeamParticipationInMatchWithNumberOfMatches");
        }
    }
}
