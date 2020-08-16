using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DataAcces.Migrations
{
    public partial class EDITpriceproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeforePrice",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "NewPrice",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b7db900e-eda7-49c8-af68-dfbc9615cd98");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace800ca-6df1-415a-9cf4-2c48f3f125ba",
                column: "ConcurrencyStamp",
                value: "bde4b1f4-ee22-43d6-8e3b-eb5d9814290c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17cbb1b-adea-43b0-af7f-33c85a5cb976",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23f1a852-264c-47ed-ba12-c9cdd05d6f12", "AQAAAAEAACcQAAAAEAEGUWQmesC2GdWadTHF6PPdFUb91UVhUlRj7DqDQt5wMHebKh8iP/XJq7rhtVePbg==", "df8f8361-96e1-40d7-9ea0-c5dba575fd26" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewPrice",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "BeforePrice",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "da772af5-1722-4562-bbbe-a38c619d6562");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace800ca-6df1-415a-9cf4-2c48f3f125ba",
                column: "ConcurrencyStamp",
                value: "90c38d1e-b4a5-479c-a2be-f572de03df49");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17cbb1b-adea-43b0-af7f-33c85a5cb976",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "015580cd-9685-4fcf-a16b-613008fddfb2", "AQAAAAEAACcQAAAAEAiqajFP5psSToWRGrnYOjhfMmpeEtNHgNileDxSnHn1x+JKrPw6+75KaL+xtxoztQ==", "a0d16a8e-397d-4421-bc95-bb9a101ccaf9" });
        }
    }
}
