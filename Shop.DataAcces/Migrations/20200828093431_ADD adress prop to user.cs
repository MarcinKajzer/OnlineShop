using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.DataAcces.Migrations
{
    public partial class ADDadressproptouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c37c34d7-922f-479b-bf22-803684a38439");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ace800ca-6df1-415a-9cf4-2c48f3f125ba",
                column: "ConcurrencyStamp",
                value: "6b659650-22fe-48d1-b112-df91223dd914");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17cbb1b-adea-43b0-af7f-33c85a5cb976",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "566cb5ce-2d14-4897-8989-ba27181ab115", "AQAAAAEAACcQAAAAEE4hk8LpYz1RTExg24r2M/SH5729xx+gVb6i1NTpBf58i+fpoZEDP9HuYrzZprF8iQ==", "810d0733-83f3-4c3b-b54c-ef3c4c562af3" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdressId",
                table: "AspNetUsers",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Adress_AdressId",
                table: "AspNetUsers",
                column: "AdressId",
                principalTable: "Adress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Adress_AdressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AdressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "AspNetUsers");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f23b7fb6-94dd-4d31-809a-d55edea5a416", "AQAAAAEAACcQAAAAELhB4ZM7xxwMNC4FmEfq4htRwczG/KBn6FBw1MdnFzHYM/loJDC+0Nv/mR0nD8paUQ==", "f358da8c-3ea4-4bba-96c8-349091d05b51" });
        }
    }
}
