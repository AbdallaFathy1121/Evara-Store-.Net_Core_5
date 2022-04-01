using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaraStore.Migrations
{
    public partial class addTbImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.CreateTable(
                name: "TbImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_TbImages_TbItem",
                        column: x => x.ItemId,
                        principalTable: "TbItem",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbImages_ItemId",
                table: "TbImages",
                column: "ItemId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbImages");

        }
    }
}
