using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetInfo.Migrations.Document
{
    public partial class DocumentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    universityId = table.Column<Guid>(nullable: false),
                    institutionId = table.Column<Guid>(nullable: true),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    contentType = table.Column<string>(maxLength: 50, nullable: false),
                    fileData = table.Column<byte[]>(nullable: false),
                    uploadedOn = table.Column<DateTime>(nullable: false),
                    uploadedBy = table.Column<string>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
