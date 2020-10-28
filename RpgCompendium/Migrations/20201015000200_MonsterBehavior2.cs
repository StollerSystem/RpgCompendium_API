using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgCompendium.Migrations
{
    public partial class MonsterBehavior2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonsterBehavior_Behaviors_BehaviorId",
                table: "MonsterBehavior");

            migrationBuilder.DropForeignKey(
                name: "FK_MonsterBehavior_Monsters_MonsterId",
                table: "MonsterBehavior");

            migrationBuilder.DropForeignKey(
                name: "FK_MonsterMainType_MainTypes_MainTypeId",
                table: "MonsterMainType");

            migrationBuilder.DropForeignKey(
                name: "FK_MonsterMainType_Monsters_MonsterId",
                table: "MonsterMainType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonsterMainType",
                table: "MonsterMainType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonsterBehavior",
                table: "MonsterBehavior");

            migrationBuilder.RenameTable(
                name: "MonsterMainType",
                newName: "MonsterMainTypes");

            migrationBuilder.RenameTable(
                name: "MonsterBehavior",
                newName: "MonsterBehaviors");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterMainType_MonsterId",
                table: "MonsterMainTypes",
                newName: "IX_MonsterMainTypes_MonsterId");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterMainType_MainTypeId",
                table: "MonsterMainTypes",
                newName: "IX_MonsterMainTypes_MainTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterBehavior_MonsterId",
                table: "MonsterBehaviors",
                newName: "IX_MonsterBehaviors_MonsterId");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterBehavior_BehaviorId",
                table: "MonsterBehaviors",
                newName: "IX_MonsterBehaviors_BehaviorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonsterMainTypes",
                table: "MonsterMainTypes",
                column: "MonsterMainTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonsterBehaviors",
                table: "MonsterBehaviors",
                column: "MonsterBehaviorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterBehaviors_Behaviors_BehaviorId",
                table: "MonsterBehaviors",
                column: "BehaviorId",
                principalTable: "Behaviors",
                principalColumn: "BehaviorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterBehaviors_Monsters_MonsterId",
                table: "MonsterBehaviors",
                column: "MonsterId",
                principalTable: "Monsters",
                principalColumn: "MonsterId",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonsterBehaviors_Behaviors_BehaviorId",
                table: "MonsterBehaviors");

            migrationBuilder.DropForeignKey(
                name: "FK_MonsterBehaviors_Monsters_MonsterId",
                table: "MonsterBehaviors");

            migrationBuilder.DropForeignKey(
                name: "FK_MonsterMainTypes_MainTypes_MainTypeId",
                table: "MonsterMainTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MonsterMainTypes_Monsters_MonsterId",
                table: "MonsterMainTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonsterMainTypes",
                table: "MonsterMainTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonsterBehaviors",
                table: "MonsterBehaviors");

            migrationBuilder.RenameTable(
                name: "MonsterMainTypes",
                newName: "MonsterMainType");

            migrationBuilder.RenameTable(
                name: "MonsterBehaviors",
                newName: "MonsterBehavior");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterMainTypes_MonsterId",
                table: "MonsterMainType",
                newName: "IX_MonsterMainType_MonsterId");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterMainTypes_MainTypeId",
                table: "MonsterMainType",
                newName: "IX_MonsterMainType_MainTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterBehaviors_MonsterId",
                table: "MonsterBehavior",
                newName: "IX_MonsterBehavior_MonsterId");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterBehaviors_BehaviorId",
                table: "MonsterBehavior",
                newName: "IX_MonsterBehavior_BehaviorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonsterMainType",
                table: "MonsterMainType",
                column: "MonsterMainTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonsterBehavior",
                table: "MonsterBehavior",
                column: "MonsterBehaviorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterBehavior_Behaviors_BehaviorId",
                table: "MonsterBehavior",
                column: "BehaviorId",
                principalTable: "Behaviors",
                principalColumn: "BehaviorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterBehavior_Monsters_MonsterId",
                table: "MonsterBehavior",
                column: "MonsterId",
                principalTable: "Monsters",
                principalColumn: "MonsterId",
                onDelete: ReferentialAction.Cascade);

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
    }
}
