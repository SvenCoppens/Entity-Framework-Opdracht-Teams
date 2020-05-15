using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamsLibrary.Migrations
{
    public partial class testingRequireds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Teams_OudTeamStamNummer",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Spelers_SpelerID",
                table: "Transfers");

            migrationBuilder.AlterColumn<int>(
                name: "SpelerID",
                table: "Transfers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OudTeamStamNummer",
                table: "Transfers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Teams",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Teams_OudTeamStamNummer",
                table: "Transfers",
                column: "OudTeamStamNummer",
                principalTable: "Teams",
                principalColumn: "StamNummer",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Spelers_SpelerID",
                table: "Transfers",
                column: "SpelerID",
                principalTable: "Spelers",
                principalColumn: "SpelerID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Teams_OudTeamStamNummer",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Spelers_SpelerID",
                table: "Transfers");

            migrationBuilder.AlterColumn<int>(
                name: "SpelerID",
                table: "Transfers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OudTeamStamNummer",
                table: "Transfers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Teams_OudTeamStamNummer",
                table: "Transfers",
                column: "OudTeamStamNummer",
                principalTable: "Teams",
                principalColumn: "StamNummer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Spelers_SpelerID",
                table: "Transfers",
                column: "SpelerID",
                principalTable: "Spelers",
                principalColumn: "SpelerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
