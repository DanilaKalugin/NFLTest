using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class UpdateAlternateKeyInStadium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Stadiums_StadiumTitle",
                table: "Stadiums");

            migrationBuilder.AlterColumn<short>(
                name: "StadiumLocation",
                table: "Stadiums",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Stadiums_StadiumTitle_StadiumLocation",
                table: "Stadiums",
                columns: new[] { "StadiumTitle", "StadiumLocation" });

            migrationBuilder.CreateIndex(
                name: "IX_Stadiums_StadiumLocation",
                table: "Stadiums",
                column: "StadiumLocation");

            migrationBuilder.AddForeignKey(
                name: "FK_Stadiums_Cities_StadiumLocation",
                table: "Stadiums",
                column: "StadiumLocation",
                principalTable: "Cities",
                principalColumn: "CityCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stadiums_Cities_StadiumLocation",
                table: "Stadiums");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Stadiums_StadiumTitle_StadiumLocation",
                table: "Stadiums");

            migrationBuilder.DropIndex(
                name: "IX_Stadiums_StadiumLocation",
                table: "Stadiums");

            migrationBuilder.AlterColumn<string>(
                name: "StadiumLocation",
                table: "Stadiums",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Stadiums_StadiumTitle",
                table: "Stadiums",
                column: "StadiumTitle");
        }
    }
}
