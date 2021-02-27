using Microsoft.EntityFrameworkCore.Migrations;

namespace Questioner.Repository.Migrations
{
    public partial class AddPassRateFieldInThemeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "PassRate",
                table: "Themes",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)80);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassRate",
                table: "Themes");
        }
    }
}
