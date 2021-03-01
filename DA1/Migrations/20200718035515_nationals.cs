using Microsoft.EntityFrameworkCore.Migrations;

namespace DA1.Migrations
{
    public partial class nationals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "103a48fb-1c0a-40eb-85a7-e279bbf43e79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8edef3e-6545-4dd7-82d8-aa20675d3c14");

            migrationBuilder.AddColumn<int>(
                name: "NationalId",
                table: "movieViewModels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalViewModelNationalId",
                table: "movieViewModels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NationalViewModels",
                columns: table => new
                {
                    NationalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalViewModels", x => x.NationalId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3132a6dc-d322-4373-8290-d26fdf2a32ef", "c82520c2-4b13-4e35-94f8-fb2ab31a4c85", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4345ae3-9590-4b8b-8b10-23677832a07e", "3d629977-7ef1-4257-900c-a860f6dc23b8", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_movieViewModels_NationalViewModelNationalId",
                table: "movieViewModels",
                column: "NationalViewModelNationalId");

            migrationBuilder.AddForeignKey(
                name: "FK_movieViewModels_NationalViewModels_NationalViewModelNationalId",
                table: "movieViewModels",
                column: "NationalViewModelNationalId",
                principalTable: "NationalViewModels",
                principalColumn: "NationalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movieViewModels_NationalViewModels_NationalViewModelNationalId",
                table: "movieViewModels");

            migrationBuilder.DropTable(
                name: "NationalViewModels");

            migrationBuilder.DropIndex(
                name: "IX_movieViewModels_NationalViewModelNationalId",
                table: "movieViewModels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3132a6dc-d322-4373-8290-d26fdf2a32ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4345ae3-9590-4b8b-8b10-23677832a07e");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "movieViewModels");

            migrationBuilder.DropColumn(
                name: "NationalViewModelNationalId",
                table: "movieViewModels");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "103a48fb-1c0a-40eb-85a7-e279bbf43e79", "ecb5f278-1ceb-4c88-9ec8-92adfa6eb610", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8edef3e-6545-4dd7-82d8-aa20675d3c14", "fbe4610f-2a5c-4d7e-bb8a-21b429f2370a", "Administrator", "ADMINISTRATOR" });
        }
    }
}
