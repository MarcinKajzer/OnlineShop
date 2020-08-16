using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DataAcces.Migrations
{
    public partial class ADDuserrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8c2e314c-cbdc-4afe-842f-f178729565d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ace800ca-6df1-415a-9cf4-2c48f3f125ba", "65ccc249-55da-489d-8a30-2c8f321326e8", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17cbb1b-adea-43b0-af7f-33c85a5cb976",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be0b203b-8483-4649-9376-93a49cc6bb57", "AQAAAAEAACcQAAAAEHRV9KNBzMO31EyPcIeNVanvttmbfTXQQGpzEnDcZwsPTKNEZeA3G/Ci6lCYFzd5kg==", "adc0142e-ed1c-47e5-aad4-1a0a46ab3ebb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace800ca-6df1-415a-9cf4-2c48f3f125ba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "db354a9b-5965-45a4-acac-0b9da829ebc0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17cbb1b-adea-43b0-af7f-33c85a5cb976",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "333e5b08-c488-4005-9619-0cb8e23cfa73", "AQAAAAEAACcQAAAAELEI2Hc7/hpGuu4Py0gS1D5UZ1cHP+eUU5UwaNG29zpTNxm4X9htE5zjcl5+UW74kA==", "643a15b6-8d23-4fdd-9d26-c9d61d61160c" });
        }
    }
}
