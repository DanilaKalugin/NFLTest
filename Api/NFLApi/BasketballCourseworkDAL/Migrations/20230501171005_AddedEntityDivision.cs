using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class AddedEntityDivision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "ConferenceLevel",
                table: "Conferences",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateTable(
                name: "NationalDivisions",
                columns: table => new
                {
                    DivisionId = table.Column<byte>(type: "tinyint", nullable: false),
                    DivisionTitle = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalDivisions", x => x.DivisionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NationalDivisions");

            migrationBuilder.AlterColumn<byte>(
                name: "ConferenceLevel",
                table: "Conferences",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);
        }
    }
}
