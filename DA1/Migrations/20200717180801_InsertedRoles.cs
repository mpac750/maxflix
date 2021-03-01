using Microsoft.EntityFrameworkCore.Migrations;

namespace DA1.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4e7b247-f3d6-424d-be88-3820b1dd802c", "c6474ada-5e58-4fe0-8ea0-7c3c2c14c491", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c5c67e6-b545-4639-8bf6-e77b9e58bb88", "30023f85-604d-40d9-85ad-eb963915c603", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c5c67e6-b545-4639-8bf6-e77b9e58bb88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4e7b247-f3d6-424d-be88-3820b1dd802c");
        }
    }
}
