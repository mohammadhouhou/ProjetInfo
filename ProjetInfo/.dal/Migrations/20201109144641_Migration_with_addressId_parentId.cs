using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetInfo.Migrations
{
    public partial class Migration_with_addressId_parentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "adressId",
                table: "institutions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "contactInfoId",
                table: "institutions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adressId",
                table: "institutions");

            migrationBuilder.DropColumn(
                name: "contactInfoId",
                table: "institutions");
        }
    }
}
