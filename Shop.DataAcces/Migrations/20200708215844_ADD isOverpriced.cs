using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DataAcces.Migrations
{
    public partial class ADDisOverpriced : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isArchived",
                table: "Items",
                newName: "IsArchived");

            migrationBuilder.AddColumn<double>(
                name: "BeforePrice",
                table: "Items",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOverpriced",
                table: "Items",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeforePrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsOverpriced",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "IsArchived",
                table: "Items",
                newName: "isArchived");
        }
    }
}
