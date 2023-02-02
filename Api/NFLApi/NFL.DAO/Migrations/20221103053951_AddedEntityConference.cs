using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class AddedEntityConference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DivisionTitle",
                table: "Divisions",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<byte>(
                name: "ConferenceId",
                table: "Divisions",
                type: "tinyint",
                nullable: true,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    ConferenceId = table.Column<byte>(type: "tinyint", nullable: false),
                    ConferenceName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    ConferenceColor = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.ConferenceId);
                    table.UniqueConstraint("AK_Conferences_ConferenceName", x => x.ConferenceName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ConferenceId",
                table: "Divisions",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Conferences_ConferenceId",
                table: "Divisions",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "ConferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Conferences_ConferenceId",
                table: "Divisions");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_ConferenceId",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "Divisions");

            migrationBuilder.AlterColumn<string>(
                name: "DivisionTitle",
                table: "Divisions",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);
        }
    }
}
