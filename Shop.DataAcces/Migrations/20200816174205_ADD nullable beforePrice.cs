using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DataAcces.Migrations
{
    public partial class ADDnullablebeforePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "BeforePrice",
                table: "Products",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<double>(
                name: "BeforePrice",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8c2e314c-cbdc-4afe-842f-f178729565d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace800ca-6df1-415a-9cf4-2c48f3f125ba",
                column: "ConcurrencyStamp",
                value: "65ccc249-55da-489d-8a30-2c8f321326e8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17cbb1b-adea-43b0-af7f-33c85a5cb976",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be0b203b-8483-4649-9376-93a49cc6bb57", "AQAAAAEAACcQAAAAEHRV9KNBzMO31EyPcIeNVanvttmbfTXQQGpzEnDcZwsPTKNEZeA3G/Ci6lCYFzd5kg==", "adc0142e-ed1c-47e5-aad4-1a0a46ab3ebb" });
        }
    }
}
