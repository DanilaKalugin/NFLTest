using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class PropertesCapacityAndOpeningYearAddedToEntityStadium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StadiumCapacity",
                table: "Stadiums",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "StadiumOpeningYear",
                table: "Stadiums",
                type: "smallint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StadiumCapacity",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "StadiumOpeningYear",
                table: "Stadiums");
        }
    }
}
