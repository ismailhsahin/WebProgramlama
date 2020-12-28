using Microsoft.EntityFrameworkCore.Migrations;

namespace Site.Data.Migrations
{
    public partial class eklefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fotograf",
                table: "Yazi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fotograf",
                table: "Yazi");
        }
    }
}
