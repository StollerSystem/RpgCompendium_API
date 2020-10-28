using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgCompendium.Migrations
{
    public partial class WeaponAndItemPropertyAndItemPropertyJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeaponSlot",
                table: "Weapons",
                newName: "WeaponProperties");

            migrationBuilder.AddColumn<string>(
                name: "WeaponSlot",
                table: "MonsterWeapons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemProperties",
                columns: table => new
                {
                    ItemPropertyId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemPropertyName = table.Column<string>(nullable: true),
                    ItemPropertyDescription = table.Column<string>(nullable: true),
                    ItemPropertyFlags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemProperties", x => x.ItemPropertyId);
                });

            migrationBuilder.CreateTable(
                name: "ItemPropertyJoins",
                columns: table => new
                {
                    ItemPropertyJoinId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ArmorId = table.Column<int>(nullable: true),
                    WeaponId = table.Column<int>(nullable: true),
                    ItemPropertyId = table.Column<int>(nullable: true),
                    ItemPropertyId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPropertyJoins", x => x.ItemPropertyJoinId);
                    table.ForeignKey(
                        name: "FK_ItemPropertyJoins_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "ArmorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPropertyJoins_ItemProperties_ItemPropertyId",
                        column: x => x.ItemPropertyId,
                        principalTable: "ItemProperties",
                        principalColumn: "ItemPropertyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPropertyJoins_ItemProperties_ItemPropertyId1",
                        column: x => x.ItemPropertyId1,
                        principalTable: "ItemProperties",
                        principalColumn: "ItemPropertyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPropertyJoins_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "WeaponId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPropertyJoins_ArmorId",
                table: "ItemPropertyJoins",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPropertyJoins_ItemPropertyId",
                table: "ItemPropertyJoins",
                column: "ItemPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPropertyJoins_ItemPropertyId1",
                table: "ItemPropertyJoins",
                column: "ItemPropertyId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPropertyJoins_WeaponId",
                table: "ItemPropertyJoins",
                column: "WeaponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPropertyJoins");

            migrationBuilder.DropTable(
                name: "ItemProperties");

            migrationBuilder.DropColumn(
                name: "WeaponSlot",
                table: "MonsterWeapons");

            migrationBuilder.RenameColumn(
                name: "WeaponProperties",
                table: "Weapons",
                newName: "WeaponSlot");
        }
    }
}
