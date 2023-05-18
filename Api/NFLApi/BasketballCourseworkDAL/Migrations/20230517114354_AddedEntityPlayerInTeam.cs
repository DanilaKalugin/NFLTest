using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class AddedEntityPlayerInTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamDepthCharts",
                columns: table => new
                {
                    PlayerInTeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamAbbreviation = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    PlayerRole = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PlayerPosition = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PlayerJerseyNumber = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlayerStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamDepthCharts", x => x.PlayerInTeamId);
                    table.UniqueConstraint("AK_TeamDepthCharts_TeamAbbreviation_PlayerJerseyNumber", x => new { x.TeamAbbreviation, x.PlayerJerseyNumber });
                    table.ForeignKey(
                        name: "FK_TeamDepthCharts_Teams_TeamAbbreviation",
                        column: x => x.TeamAbbreviation,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamDepthCharts");
        }
    }
}
