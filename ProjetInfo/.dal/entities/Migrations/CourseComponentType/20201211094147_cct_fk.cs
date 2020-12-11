using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetInfo.Migrations.CourseComponentType
{
    public partial class cct_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "owner",
                table: "CourseComponentTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "owner",
                table: "CourseComponentTypes");
        }
    }
}
