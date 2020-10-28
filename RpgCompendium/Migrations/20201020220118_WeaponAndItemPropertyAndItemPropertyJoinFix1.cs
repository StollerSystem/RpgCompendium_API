using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgCompendium.Migrations
{
    public partial class WeaponAndItemPropertyAndItemPropertyJoinFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPropertyJoins_ItemProperties_ItemPropertyId",
                table: "ItemPropertyJoins");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPropertyJoins_ItemProperties_ItemPropertyId1",
                table: "ItemPropertyJoins");

            migrationBuilder.DropIndex(
                name: "IX_ItemPropertyJoins_ItemPropertyId1",
                table: "ItemPropertyJoins");

            migrationBuilder.DropColumn(
                name: "ItemPropertyId1",
                table: "ItemPropertyJoins");

            migrationBuilder.AlterColumn<int>(
                name: "ItemPropertyId",
                table: "ItemPropertyJoins",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPropertyJoins_ItemProperties_ItemPropertyId",
                table: "ItemPropertyJoins",
                column: "ItemPropertyId",
                principalTable: "ItemProperties",
                principalColumn: "ItemPropertyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPropertyJoins_ItemProperties_ItemPropertyId",
                table: "ItemPropertyJoins");

            migrationBuilder.AlterColumn<int>(
                name: "ItemPropertyId",
                table: "ItemPropertyJoins",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ItemPropertyId1",
                table: "ItemPropertyJoins",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemPropertyJoins_ItemPropertyId1",
                table: "ItemPropertyJoins",
                column: "ItemPropertyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPropertyJoins_ItemProperties_ItemPropertyId",
                table: "ItemPropertyJoins",
                column: "ItemPropertyId",
                principalTable: "ItemProperties",
                principalColumn: "ItemPropertyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPropertyJoins_ItemProperties_ItemPropertyId1",
                table: "ItemPropertyJoins",
                column: "ItemPropertyId1",
                principalTable: "ItemProperties",
                principalColumn: "ItemPropertyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
