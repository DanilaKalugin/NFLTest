using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class AddedPropertyFavoriteTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FavoriteTeam",
                table: "Users",
                type: "nvarchar(5)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FavoriteTeam",
                table: "Users",
                column: "FavoriteTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_FavoriteTeam",
                table: "Users",
                column: "FavoriteTeam",
                principalTable: "Teams",
                principalColumn: "TeamAbbreviation",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_FavoriteTeam",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FavoriteTeam",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FavoriteTeam",
                table: "Users");
        }
    }
}
