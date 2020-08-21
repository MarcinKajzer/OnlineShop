using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DataAcces.Migrations
{
    public partial class ADDPostCodeproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInfo_Products_ProductId",
                table: "ProductInfo");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Adress",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e7e6a549-8201-41bf-bd75-7e8a127623b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace800ca-6df1-415a-9cf4-2c48f3f125ba",
                column: "ConcurrencyStamp",
                value: "be1f0ef6-aa4d-4aed-9e23-7c3a0f96a83f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17cbb1b-adea-43b0-af7f-33c85a5cb976",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39228993-8747-4e43-b75a-fd6de920f84a", "AQAAAAEAACcQAAAAEEuYVdcI8SOiYmanjFQvSeM+s8Qy6xhVYNDnoXhqE4gx5+3wW3rqh+CfiaCb0M8IGQ==", "57edb9ce-00e7-4354-9f76-4560f696aa3a" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInfo_Products_ProductId",
                table: "ProductInfo",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInfo_Products_ProductId",
                table: "ProductInfo");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Adress");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "975e67aa-e418-46bb-a4e1-5c402fe572ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace800ca-6df1-415a-9cf4-2c48f3f125ba",
                column: "ConcurrencyStamp",
                value: "cab182c7-55a7-4700-a405-a41ed72b51ed");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17cbb1b-adea-43b0-af7f-33c85a5cb976",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ae51ce7-6a73-455e-af9b-d6b033c666a5", "AQAAAAEAACcQAAAAEHks3St/VPUAAubjhbDGOhh8Wc56mbhY723WiRn5xrCmitnOQgep7Ximo5KZ86GIjQ==", "f066256f-dc13-4096-8f70-6ee42bd7e278" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInfo_Products_ProductId",
                table: "ProductInfo",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
