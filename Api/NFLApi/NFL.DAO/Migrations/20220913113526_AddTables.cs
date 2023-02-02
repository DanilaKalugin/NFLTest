using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    DivisionNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    DivisionTitle = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionNumber);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    StadiumId = table.Column<short>(type: "smallint", nullable: false),
                    StadiumTitle = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    StadiumLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.StadiumId);
                    table.UniqueConstraint("AK_Stadiums_StadiumTitle", x => x.StadiumTitle);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamAbbreviation = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TeamRegion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    StadiumId = table.Column<short>(type: "smallint", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamDivision = table.Column<byte>(type: "tinyint", nullable: false),
                    Coach = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamAbbreviation);
                    table.ForeignKey(
                        name: "FK_Teams_Divisions_TeamDivision",
                        column: x => x.TeamDivision,
                        principalTable: "Divisions",
                        principalColumn: "DivisionNumber");
                    table.ForeignKey(
                        name: "FK_Teams_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "StadiumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StadiumId",
                table: "Teams",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamDivision",
                table: "Teams",
                column: "TeamDivision");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Stadiums");
        }
    }
}
