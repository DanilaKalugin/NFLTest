using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFL.DAO.Migrations
{
    public partial class AddedEntitiySocialNetworkAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialNetworkAccountTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworkAccountTypes", x => x.Id);
                    table.UniqueConstraint("AK_SocialNetworkAccountTypes_Description", x => x.Description);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworkAccounts",
                columns: table => new
                {
                    TeamAbbreviation = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    AccountTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworkAccounts", x => new { x.TeamAbbreviation, x.AccountTypeId });
                    table.ForeignKey(
                        name: "FK_SocialNetworkAccounts_Teams_TeamAbbreviation",
                        column: x => x.TeamAbbreviation,
                        principalTable: "Teams",
                        principalColumn: "TeamAbbreviation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialNetworkAccounts_SocialNetworkAccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "SocialNetworkAccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SocialNetworkAccountTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { (byte)1, "TeamSite" });

            migrationBuilder.InsertData(
                table: "SocialNetworkAccountTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { (byte)2, "TwitterAccount" });

            migrationBuilder.InsertData(
                table: "SocialNetworkAccountTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { (byte)3, "FacebookPage" });

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworkAccounts_AccountTypeId",
                table: "SocialNetworkAccounts",
                column: "AccountTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialNetworkAccounts");

            migrationBuilder.DropTable(
                name: "SocialNetworkAccountTypes");
        }
    }
}
