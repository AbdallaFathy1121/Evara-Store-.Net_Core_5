using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaraStore.Migrations
{
    public partial class Update_TbRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbRate_TbItems",
                table: "TbRate");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "TbRate",
                newName: "Star");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItem_TbRate",
                table: "TbRate",
                column: "ItemId",
                principalTable: "TbItem",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItem_TbRate",
                table: "TbRate");

            migrationBuilder.RenameColumn(
                name: "Star",
                table: "TbRate",
                newName: "Rate");

            migrationBuilder.AddForeignKey(
                name: "FK_TbRate_TbItems",
                table: "TbRate",
                column: "ItemId",
                principalTable: "TbItem",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
