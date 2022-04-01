using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaraStore.Migrations
{
    public partial class Updat_TbItem22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
