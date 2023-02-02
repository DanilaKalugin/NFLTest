using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class AddedEntityTeamColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Teams");

            migrationBuilder.CreateTable(
                name: "teamColors",
                columns: table => new
                {
                    TeamAbbreviation = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    ColorNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teamColors", x => new { x.TeamAbbreviation, x.ColorNumber });
                    table.ForeignKey(
                        name: "FK_teamColors_Teams_TeamAbbreviation",
                        column: x => x.TeamAbbreviation,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teamColors");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
