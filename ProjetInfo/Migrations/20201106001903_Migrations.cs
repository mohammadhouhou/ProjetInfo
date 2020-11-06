using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetInfo.Migrations
{
    public partial class Migrations : Migration
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
                    parentId = table.Column<Guid>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    institutionid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutions", x => x.id);
                    table.ForeignKey(
                        name: "FK_institutions_institutions_institutionid",
                        column: x => x.institutionid,
                        principalTable: "institutions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityCategory",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    exclusive = table.Column<bool>(nullable: false),
                    required = table.Column<bool>(nullable: false),
                    owner = table.Column<Guid>(nullable: false),
                    institutionid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCategory", x => x.id);
                    table.ForeignKey(
                        name: "FK_ActivityCategory_institutions_institutionid",
                        column: x => x.institutionid,
                        principalTable: "institutions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCategory_institutionid",
                table: "ActivityCategory",
                column: "institutionid");

            migrationBuilder.CreateIndex(
                name: "IX_institutions_institutionid",
                table: "institutions",
                column: "institutionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityCategory");

            migrationBuilder.DropTable(
                name: "institutions");
        }
    }
}
