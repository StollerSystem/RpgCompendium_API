using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgCompendium.Migrations
{
    public partial class Authorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Monsters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_UserId",
                table: "Monsters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_AspNetUsers_UserId",
                table: "Monsters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_AspNetUsers_UserId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_UserId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Monsters");
        }
    }
}
