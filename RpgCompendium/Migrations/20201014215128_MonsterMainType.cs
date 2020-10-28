using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgCompendium.Migrations
{
    public partial class MonsterMainType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonsterMainTypes",
                columns: table => new
                {
                    MonsterMainTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MonsterId = table.Column<int>(nullable: false),
                    MainTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterMainTypes", x => x.MonsterMainTypeId);
                    table.ForeignKey(
                        name: "FK_MonsterMainTypes_MainTypes_MainTypeId",
                        column: x => x.MainTypeId,
                        principalTable: "MainTypes",
                        principalColumn: "MainTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterMainTypes_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonsterMainTypes_MainTypeId",
                table: "MonsterMainTypes",
                column: "MainTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterMainTypes_MonsterId",
                table: "MonsterMainTypes",
                column: "MonsterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonsterMainTypes");
        }
    }
}
