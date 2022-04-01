using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaraStore.Migrations
{
    public partial class DeleteColum_Sizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "L",
                table: "TbItem");

            migrationBuilder.DropColumn(
                name: "M",
                table: "TbItem");

            migrationBuilder.DropColumn(
                name: "S",
                table: "TbItem");

            migrationBuilder.DropColumn(
                name: "XL",
                table: "TbItem");

            migrationBuilder.DropColumn(
                name: "XXL",
                table: "TbItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "L",
                table: "TbItem",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "M",
                table: "TbItem",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "S",
                table: "TbItem",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "XL",
                table: "TbItem",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "XXL",
                table: "TbItem",
                type: "bit",
                nullable: true);
        }
    }
}
