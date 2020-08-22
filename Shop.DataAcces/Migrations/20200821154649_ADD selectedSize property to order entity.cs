using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DataAcces.Migrations
{
    public partial class ADDselectedSizepropertytoorderentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelectedSize",
                table: "ProductInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "cdf375cd-4326-48cc-b6bd-96866d862114");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace800ca-6df1-415a-9cf4-2c48f3f125ba",
                column: "ConcurrencyStamp",
                value: "3127f5c9-fb8b-44fa-b4b5-bc6bb826910d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17cbb1b-adea-43b0-af7f-33c85a5cb976",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9aae056e-5d71-4e19-8917-3d8d285821c6", "AQAAAAEAACcQAAAAEKjdk1LQPzSs45qzbKzmDkD6wgcFlsTYmdph/M0VQ/+QWy+SjAd/TF2pg+OcvQJ1qQ==", "efa255ef-99a9-4522-b5b4-3ee58c816c5c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedSize",
                table: "ProductInfo");

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
        }
    }
}
