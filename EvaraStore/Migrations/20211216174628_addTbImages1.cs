using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaraStore.Migrations
{
    public partial class addTbImages1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbImages_TbItem_TbItemItemId",
                table: "TbImages");

            migrationBuilder.DropIndex(
                name: "IX_TbImages_TbItemItemId",
                table: "TbImages");

            migrationBuilder.DropColumn(
                name: "TbItemItemId",
                table: "TbImages");
        }
    }
}
