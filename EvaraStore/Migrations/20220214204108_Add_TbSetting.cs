using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaraStore.Migrations
{
    public partial class Add_TbSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbSetting",
                columns: table => new
                {
                    SettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainPhone = table.Column<int>(type: "int", nullable: false),
                    HotLinePhone = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insatgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pinterest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTube = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSetting", x => x.SettingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbSetting");
        }
    }
}
