﻿using System;
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
                    parentId = table.Column<Guid>(nullable: true),
                    type = table.Column<int>(nullable: false)
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
