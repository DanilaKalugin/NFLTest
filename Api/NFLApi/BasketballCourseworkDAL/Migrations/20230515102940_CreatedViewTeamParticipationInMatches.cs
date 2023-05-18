using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class CreatedViewTeamParticipationInMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
    Create View TeamParticipationInMatches as
select MatchId, AwayTeam, MatchDate, IsPlayed
from matches
UNION
select MatchId, HomeTeam, MatchDate, IsPlayed
from matches
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROp VIEW TeamParticipationInMatches");
        }
    }
}
