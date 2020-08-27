using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DataAcces.Migrations
{
    public partial class SETemailConfirmationtotrue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "02112dcb-0788-434a-a955-a965174f4c49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace800ca-6df1-415a-9cf4-2c48f3f125ba",
                column: "ConcurrencyStamp",
                value: "ca6c41e9-bcaf-41b7-9c03-e72d51b91624");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17cbb1b-adea-43b0-af7f-33c85a5cb976",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f23b7fb6-94dd-4d31-809a-d55edea5a416", true, "AQAAAAEAACcQAAAAELhB4ZM7xxwMNC4FmEfq4htRwczG/KBn6FBw1MdnFzHYM/loJDC+0Nv/mR0nD8paUQ==", "f358da8c-3ea4-4bba-96c8-349091d05b51" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9aae056e-5d71-4e19-8917-3d8d285821c6", false, "AQAAAAEAACcQAAAAEKjdk1LQPzSs45qzbKzmDkD6wgcFlsTYmdph/M0VQ/+QWy+SjAd/TF2pg+OcvQJ1qQ==", "efa255ef-99a9-4522-b5b4-3ee58c816c5c" });
        }
    }
}
