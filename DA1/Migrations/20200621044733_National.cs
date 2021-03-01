using Microsoft.EntityFrameworkCore.Migrations;

namespace DA1.Migrations
{
    public partial class National : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieTime",
                table: "MOVIEs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalId",
                table: "MOVIEs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NATIONALs",
                columns: table => new
                {
                    NationalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NATIONALs", x => x.NationalId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MOVIEs_NationalId",
                table: "MOVIEs",
                column: "NationalId");

            migrationBuilder.AddForeignKey(
                name: "FK_MOVIEs_NATIONALs_NationalId",
                table: "MOVIEs",
                column: "NationalId",
                principalTable: "NATIONALs",                principalColumn: "NationalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MOVIEs_NATIONALs_NationalId",
                table: "MOVIEs");

            migrationBuilder.DropTable(
                name: "NATIONALs");

            migrationBuilder.DropIndex(
                name: "IX_MOVIEs_NationalId",
                table: "MOVIEs");

            migrationBuilder.DropColumn(
                name: "MovieTime",
                table: "MOVIEs");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "MOVIEs");
        }
    }
}
