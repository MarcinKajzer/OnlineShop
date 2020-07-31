using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DataAcces.Migrations
{
    public partial class RenamesizetosizeInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.CreateTable(
                name: "SizeInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeInfo_Items_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SizeInfo_ProductId",
                table: "SizeInfo",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SizeInfo");

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Size_Items_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Size_ProductId",
                table: "Size",
                column: "ProductId");
        }
    }
}
