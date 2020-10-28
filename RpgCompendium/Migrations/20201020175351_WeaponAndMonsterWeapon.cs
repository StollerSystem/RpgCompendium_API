using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgCompendium.Migrations
{
    public partial class WeaponAndMonsterWeapon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonsterArmor_Armors_ArmorId",
                table: "MonsterArmor");

            migrationBuilder.DropForeignKey(
                name: "FK_MonsterArmor_Monsters_MonsterId",
                table: "MonsterArmor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonsterArmor",
                table: "MonsterArmor");

            migrationBuilder.DropColumn(
                name: "ArmorSlot",
                table: "MonsterArmor");

            migrationBuilder.RenameTable(
                name: "MonsterArmor",
                newName: "MonsterArmors");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterArmor_MonsterId",
                table: "MonsterArmors",
                newName: "IX_MonsterArmors_MonsterId");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterArmor_ArmorId",
                table: "MonsterArmors",
                newName: "IX_MonsterArmors_ArmorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonsterArmors",
                table: "MonsterArmors",
                column: "MonsterArmorId");

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    WeaponId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WeaponName = table.Column<string>(nullable: true),
                    WeaponDescription = table.Column<string>(nullable: true),
                    WeaponSlot = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.WeaponId);
                });

            migrationBuilder.CreateTable(
                name: "MonsterWeapons",
                columns: table => new
                {
                    MonsterWeaponId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MonsterId = table.Column<int>(nullable: false),
                    WeaponId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterWeapons", x => x.MonsterWeaponId);
                    table.ForeignKey(
                        name: "FK_MonsterWeapons_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterWeapons_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "WeaponId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonsterWeapons_MonsterId",
                table: "MonsterWeapons",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterWeapons_WeaponId",
                table: "MonsterWeapons",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterArmors_Armors_ArmorId",
                table: "MonsterArmors",
                column: "ArmorId",
                principalTable: "Armors",
                principalColumn: "ArmorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterArmors_Monsters_MonsterId",
                table: "MonsterArmors",
                column: "MonsterId",
                principalTable: "Monsters",
                principalColumn: "MonsterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonsterArmors_Armors_ArmorId",
                table: "MonsterArmors");

            migrationBuilder.DropForeignKey(
                name: "FK_MonsterArmors_Monsters_MonsterId",
                table: "MonsterArmors");

            migrationBuilder.DropTable(
                name: "MonsterWeapons");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonsterArmors",
                table: "MonsterArmors");

            migrationBuilder.RenameTable(
                name: "MonsterArmors",
                newName: "MonsterArmor");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterArmors_MonsterId",
                table: "MonsterArmor",
                newName: "IX_MonsterArmor_MonsterId");

            migrationBuilder.RenameIndex(
                name: "IX_MonsterArmors_ArmorId",
                table: "MonsterArmor",
                newName: "IX_MonsterArmor_ArmorId");

            migrationBuilder.AddColumn<string>(
                name: "ArmorSlot",
                table: "MonsterArmor",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonsterArmor",
                table: "MonsterArmor",
                column: "MonsterArmorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterArmor_Armors_ArmorId",
                table: "MonsterArmor",
                column: "ArmorId",
                principalTable: "Armors",
                principalColumn: "ArmorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterArmor_Monsters_MonsterId",
                table: "MonsterArmor",
                column: "MonsterId",
                principalTable: "Monsters",
                principalColumn: "MonsterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
