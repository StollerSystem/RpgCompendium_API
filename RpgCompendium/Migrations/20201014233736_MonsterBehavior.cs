using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgCompendium.Migrations
{
    public partial class MonsterBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonsterMainTypes_MainTypes_MainTypeId",
                table: "MonsterMainTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MonsterMainTypes_Monsters_MonsterId",
                table: "MonsterMainTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonsterMainTypes",
                table: "MonsterMainTypes");

            migrationBuilder.RenameTable(
                name: "MonsterMainTypes",
                newName: "MonsterMainType");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterMainTypes_MonsterId",
                table: "MonsterMainType",
                newName: "IX_MonsterMainType_MonsterId");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterMainTypes_MainTypeId",
                table: "MonsterMainType",
                newName: "IX_MonsterMainType_MainTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonsterMainType",
                table: "MonsterMainType",
                column: "MonsterMainTypeId");

            migrationBuilder.CreateTable(
                name: "MonsterBehavior",
                columns: table => new
                {
                    MonsterBehaviorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MonsterId = table.Column<int>(nullable: false),
                    BehaviorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterBehavior", x => x.MonsterBehaviorId);
                    table.ForeignKey(
                        name: "FK_MonsterBehavior_Behaviors_BehaviorId",
                        column: x => x.BehaviorId,
                        principalTable: "Behaviors",
                        principalColumn: "BehaviorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterBehavior_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonsterBehavior_BehaviorId",
                table: "MonsterBehavior",
                column: "BehaviorId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterBehavior_MonsterId",
                table: "MonsterBehavior",
                column: "MonsterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterMainType_MainTypes_MainTypeId",
                table: "MonsterMainType",
                column: "MainTypeId",
                principalTable: "MainTypes",
                principalColumn: "MainTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterMainType_Monsters_MonsterId",
                table: "MonsterMainType",
                column: "MonsterId",
                principalTable: "Monsters",
                principalColumn: "MonsterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonsterMainType_MainTypes_MainTypeId",
                table: "MonsterMainType");

            migrationBuilder.DropForeignKey(
                name: "FK_MonsterMainType_Monsters_MonsterId",
                table: "MonsterMainType");

            migrationBuilder.DropTable(
                name: "MonsterBehavior");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonsterMainType",
                table: "MonsterMainType");

            migrationBuilder.RenameTable(
                name: "MonsterMainType",
                newName: "MonsterMainTypes");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterMainType_MonsterId",
                table: "MonsterMainTypes",
                newName: "IX_MonsterMainTypes_MonsterId");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterMainType_MainTypeId",
                table: "MonsterMainTypes",
                newName: "IX_MonsterMainTypes_MainTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonsterMainTypes",
                table: "MonsterMainTypes",
                column: "MonsterMainTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterMainTypes_MainTypes_MainTypeId",
                table: "MonsterMainTypes",
                column: "MainTypeId",
                principalTable: "MainTypes",
                principalColumn: "MainTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterMainTypes_Monsters_MonsterId",
                table: "MonsterMainTypes",
                column: "MonsterId",
                principalTable: "Monsters",
                principalColumn: "MonsterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
