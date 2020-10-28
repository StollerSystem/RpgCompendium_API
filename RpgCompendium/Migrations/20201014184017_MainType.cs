using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgCompendium.Migrations
{
    public partial class MainType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonsterBehaviors",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "MonsterMainType",
                table: "Monsters");

            migrationBuilder.CreateTable(
                name: "MainTypes",
                columns: table => new
                {
                    MainTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MainTypeName = table.Column<string>(nullable: true),
                    MainTypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainTypes", x => x.MainTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainTypes");

            migrationBuilder.AddColumn<string>(
                name: "MonsterBehaviors",
                table: "Monsters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonsterMainType",
                table: "Monsters",
                nullable: true);
        }
    }
}
