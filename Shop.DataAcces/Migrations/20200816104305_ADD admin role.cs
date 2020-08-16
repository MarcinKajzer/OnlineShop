using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DataAcces.Migrations
{
    public partial class ADDadminrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "db354a9b-5965-45a4-acac-0b9da829ebc0", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e17cbb1b-adea-43b0-af7f-33c85a5cb976", 0, "333e5b08-c488-4005-9619-0cb8e23cfa73", "admin@shop.com", false, "Admin", "Admin", false, null, "ADMIN@SHOP.COM", "ADMIN@SHOP.COM", "AQAAAAEAACcQAAAAELEI2Hc7/hpGuu4Py0gS1D5UZ1cHP+eUU5UwaNG29zpTNxm4X9htE5zjcl5+UW74kA==", null, false, "643a15b6-8d23-4fdd-9d26-c9d61d61160c", false, "admin@shop.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "e17cbb1b-adea-43b0-af7f-33c85a5cb976", "2c5e174e-3b0e-446f-86af-483d56fd7210" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "e17cbb1b-adea-43b0-af7f-33c85a5cb976", "2c5e174e-3b0e-446f-86af-483d56fd7210" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17cbb1b-adea-43b0-af7f-33c85a5cb976");
        }
    }
}
