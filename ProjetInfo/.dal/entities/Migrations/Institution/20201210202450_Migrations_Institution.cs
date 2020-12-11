using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetInfo.Migrations
{
    public partial class Migrations_Institution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institutions",
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
                    table.PrimaryKey("PK_Institutions", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}
