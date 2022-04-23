using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShip.Model.Migrations
{
    public partial class AjoutRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "RequiredShip",
                newName: "SizeShip");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Games",
                newName: "WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_PlayerId",
                table: "Games",
                newName: "IX_Games_WinnerId");

            migrationBuilder.AddColumn<int>(
                name: "NumberShip",
                table: "RequiredShip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_WinnerId",
                table: "Games",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_WinnerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "NumberShip",
                table: "RequiredShip");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "SizeShip",
                table: "RequiredShip",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "WinnerId",
                table: "Games",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_WinnerId",
                table: "Games",
                newName: "IX_Games_PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
