using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetInfo.Migrations.ActivityCategory
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityCategories",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(maxLength: 6, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    exclusive = table.Column<bool>(nullable: false),
                    required = table.Column<bool>(nullable: false),
                    owner = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCategories", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityCategories");
        }
    }
}
