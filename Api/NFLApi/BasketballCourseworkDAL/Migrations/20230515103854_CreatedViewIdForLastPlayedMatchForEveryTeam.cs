using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class CreatedViewIdForLastPlayedMatchForEveryTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsPlayed",
                table: "Matches",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.Sql(@"CREATE VIEW IdForLastPlayedMatchForEveryTeam
AS
select AwayTeam, MatchId
    from (select MatchId,
                 AwayTeam,
				 MatchDate,
				 IsPlayed,
                 row_number () over (partition by awayTeam order by MatchDate desc) rn
            from TeamParticipationInMatches) as Matches
WHERE rn = 1 and IsPlayed = 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsPlayed",
                table: "Matches",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.Sql("DROP VIEW IdForLastPlayedMatchForEveryTeam");
        }
    }
}
