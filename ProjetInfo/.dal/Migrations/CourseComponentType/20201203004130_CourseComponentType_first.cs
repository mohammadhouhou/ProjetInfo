using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetInfo.Migrations.CourseComponentType
{
    public partial class CourseComponentType_first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseComponentTypes",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseComponentTypes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseComponentTypes");
        }
    }
}
