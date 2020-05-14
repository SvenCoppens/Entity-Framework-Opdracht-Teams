using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamsLibrary.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    StamNummer = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Bijnaam = table.Column<string>(nullable: true),
                    Trainer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.StamNummer);
                });

            migrationBuilder.CreateTable(
                name: "Spelers",
                columns: table => new
                {
                    SpelerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    RugNummer = table.Column<int>(nullable: false),
                    TransferWaarde = table.Column<int>(nullable: false),
                    TeamStamNummer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spelers", x => x.SpelerID);
                    table.ForeignKey(
                        name: "FK_Spelers_Teams_TeamStamNummer",
                        column: x => x.TeamStamNummer,
                        principalTable: "Teams",
                        principalColumn: "StamNummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    TransferID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpelerID = table.Column<int>(nullable: false),
                    TransferPrijs = table.Column<int>(nullable: false),
                    NieuwTeamStamNummer = table.Column<int>(nullable: false),
                    OudTeamStamNummer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.TransferID);
                    table.ForeignKey(
                        name: "FK_Transfers_Teams_NieuwTeamStamNummer",
                        column: x => x.NieuwTeamStamNummer,
                        principalTable: "Teams",
                        principalColumn: "StamNummer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfers_Teams_OudTeamStamNummer",
                        column: x => x.OudTeamStamNummer,
                        principalTable: "Teams",
                        principalColumn: "StamNummer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfers_Spelers_SpelerID",
                        column: x => x.SpelerID,
                        principalTable: "Spelers",
                        principalColumn: "SpelerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spelers_TeamStamNummer",
                table: "Spelers",
                column: "TeamStamNummer");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_NieuwTeamStamNummer",
                table: "Transfers",
                column: "NieuwTeamStamNummer");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_OudTeamStamNummer",
                table: "Transfers",
                column: "OudTeamStamNummer");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_SpelerID",
                table: "Transfers",
                column: "SpelerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Spelers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
