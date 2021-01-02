using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSonHal.Data.Migrations
{
    public partial class eklendiadmin3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yazi_AspNetUsers_KisiId1",
                table: "Yazi");

            migrationBuilder.DropIndex(
                name: "IX_Yazi_KisiId1",
                table: "Yazi");

            migrationBuilder.DropColumn(
                name: "KisiId",
                table: "Yazi");

            migrationBuilder.DropColumn(
                name: "KisiId1",
                table: "Yazi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KisiId",
                table: "Yazi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "KisiId1",
                table: "Yazi",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yazi_KisiId1",
                table: "Yazi",
                column: "KisiId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Yazi_AspNetUsers_KisiId1",
                table: "Yazi",
                column: "KisiId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
