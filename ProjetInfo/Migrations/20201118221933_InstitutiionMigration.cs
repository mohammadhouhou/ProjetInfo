using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetInfo.Migrations
{
    public partial class InstitutiionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "institutions",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(maxLength: 50, nullable: false),
                    name = table.Column<string>(maxLength: 250, nullable: false),
                    type = table.Column<int>(nullable: false),
                    adressId = table.Column<int>(nullable: false),
                    contactInfoId = table.Column<int>(nullable: false),
                    parentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutions", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "institutions");
        }
    }
}
