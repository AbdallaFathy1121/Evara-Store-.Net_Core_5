using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaraStore.Migrations
{
    public partial class TbRate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbRate_TbItem_ItemId",
                table: "TbRate");

            migrationBuilder.AddForeignKey(
                name: "FK_TbRate_TbItems",
                table: "TbRate",
                column: "ItemId",
                principalTable: "TbItem",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbRate_TbItems",
                table: "TbRate");

            migrationBuilder.AddForeignKey(
                name: "FK_TbRate_TbItem_ItemId",
                table: "TbRate",
                column: "ItemId",
                principalTable: "TbItem",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
