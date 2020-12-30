using Microsoft.EntityFrameworkCore.Migrations;

namespace Site.Data.Migrations
{
    public partial class duzenlemeler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Kisi_KisiId",
                table: "Yorum");

            migrationBuilder.DropIndex(
                name: "IX_Yorum_KisiId",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "KisiId",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "YorumBaslik",
                table: "Yorum");

            migrationBuilder.AddColumn<string>(
                name: "Isim",
                table: "Yorum",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Yorum",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isim",
                table: "Yorum");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Yorum");

            migrationBuilder.AddColumn<int>(
                name: "KisiId",
                table: "Yorum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "YorumBaslik",
                table: "Yorum",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_KisiId",
                table: "Yorum",
                column: "KisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Kisi_KisiId",
                table: "Yorum",
                column: "KisiId",
                principalTable: "Kisi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
