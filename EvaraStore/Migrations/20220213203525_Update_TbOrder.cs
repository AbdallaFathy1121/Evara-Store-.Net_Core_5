using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaraStore.Migrations
{
    public partial class Update_TbOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "TbOrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageBarcode",
                table: "TbOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "TbOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderItems_ItemId",
                table: "TbOrderItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItem_TbOrderItems",
                table: "TbOrderItems",
                column: "ItemId",
                principalTable: "TbItem",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItem_TbOrderItems",
                table: "TbOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_TbOrderItems_ItemId",
                table: "TbOrderItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "TbOrderItems");

            migrationBuilder.DropColumn(
                name: "ImageBarcode",
                table: "TbOrder");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "TbOrder");
        }
    }
}
