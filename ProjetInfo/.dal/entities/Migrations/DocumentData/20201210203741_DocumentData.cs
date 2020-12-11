using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetInfo.Migrations.DocumentData
{
    public partial class DocumentData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentDatas",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    documentID = table.Column<Guid>(nullable: false),
                    fileData = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDatas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentDatas");
        }
    }
}
