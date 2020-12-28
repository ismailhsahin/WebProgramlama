using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Site.Data.Migrations
{
    public partial class ilkolusum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kisi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    YearOfBirth = table.Column<DateTime>(nullable: false),
                    Cinsiyet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yazi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(nullable: true),
                    Icerik = table.Column<string>(nullable: true),
                    OlusturulmaTarihi = table.Column<DateTime>(nullable: false),
                    TahminiOkumaSuresi = table.Column<int>(nullable: true),
                    KategoriId = table.Column<int>(nullable: false),
                    KisiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yazi_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Yazi_Kisi_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YorumBaslik = table.Column<string>(nullable: true),
                    YorumIcerik = table.Column<string>(nullable: true),
                    YaziId = table.Column<int>(nullable: false),
                    KisiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yorum_Kisi_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Yorum_Yazi_YaziId",
                        column: x => x.YaziId,
                        principalTable: "Yazi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Yazi_KategoriId",
                table: "Yazi",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Yazi_KisiId",
                table: "Yazi",
                column: "KisiId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_KisiId",
                table: "Yorum",
                column: "KisiId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_YaziId",
                table: "Yorum",
                column: "YaziId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yorum");

            migrationBuilder.DropTable(
                name: "Yazi");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Kisi");
        }
    }
}
