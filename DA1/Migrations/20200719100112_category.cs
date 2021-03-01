using Microsoft.EntityFrameworkCore.Migrations;

namespace DA1.Migrations
{
    public partial class category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "410d6c49-bc2d-4420-8cd7-afb209fdd476");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "748e82be-04bf-49ad-87de-709c6f98ecff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51ee4129-5f1f-4326-9b2d-d74c4128a188", "5fd33c3a-8649-4353-8301-051c79d5e537", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a1f4cfc-b683-4408-a66e-4741c1ec28a7", "c8d1af8e-acc2-42dd-bdec-9422a2f2f26c", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51ee4129-5f1f-4326-9b2d-d74c4128a188");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a1f4cfc-b683-4408-a66e-4741c1ec28a7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "410d6c49-bc2d-4420-8cd7-afb209fdd476", "246453b7-24e3-47b7-aaf9-83754d4a664e", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "748e82be-04bf-49ad-87de-709c6f98ecff", "c9613f51-0b98-48d4-a7fb-eca768518dd5", "Administrator", "ADMINISTRATOR" });
        }
    }
}
