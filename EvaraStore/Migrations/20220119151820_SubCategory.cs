using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaraStore.Migrations
{
    public partial class SubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "TbSubCategory",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TbSubCategory_CategoryId",
                table: "TbSubCategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbSubCategory_TbCategory",
                table: "TbSubCategory",
                column: "CategoryId",
                principalTable: "TbCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbSubCategory_TbCategory",
                table: "TbSubCategory");

            migrationBuilder.DropIndex(
                name: "IX_TbSubCategory_CategoryId",
                table: "TbSubCategory");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TbSubCategory");
        }
    }
}
