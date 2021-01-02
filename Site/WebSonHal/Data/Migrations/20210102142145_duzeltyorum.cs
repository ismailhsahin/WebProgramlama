using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSonHal.Data.Migrations
{
    public partial class duzeltyorum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_AspNetUsers_KisiId1",
                table: "Yorum");

            migrationBuilder.DropIndex(
                name: "IX_Yorum_KisiId1",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "KisiId",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "KisiId1",
                table: "Yorum");

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Yorum",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Yorum",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Soyad",
                table: "Yorum",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "Soyad",
                table: "Yorum");

            migrationBuilder.AddColumn<int>(
                name: "KisiId",
                table: "Yorum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "KisiId1",
                table: "Yorum",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_KisiId1",
                table: "Yorum",
                column: "KisiId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_AspNetUsers_KisiId1",
                table: "Yorum",
                column: "KisiId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
