using Microsoft.EntityFrameworkCore.Migrations;

namespace DA1.Migrations
{
    public partial class email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3132a6dc-d322-4373-8290-d26fdf2a32ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4345ae3-9590-4b8b-8b10-23677832a07e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7dea3e57-4a32-4d65-b343-410ee1900f2f", "908da3b6-2184-40de-a3f1-2aed52278819", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1bf0947b-9cbe-424d-a0e9-08d7453d2e8e", "98a7fd2f-d92d-4f3b-8552-8a9b74ebadae", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bf0947b-9cbe-424d-a0e9-08d7453d2e8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dea3e57-4a32-4d65-b343-410ee1900f2f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3132a6dc-d322-4373-8290-d26fdf2a32ef", "c82520c2-4b13-4e35-94f8-fb2ab31a4c85", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4345ae3-9590-4b8b-8b10-23677832a07e", "3d629977-7ef1-4257-900c-a860f6dc23b8", "Administrator", "ADMINISTRATOR" });
        }
    }
}
