using Microsoft.EntityFrameworkCore.Migrations;

namespace DA1.Migrations
{
    public partial class MovieTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieTime",
                table: "movieViewModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieTime",
                table: "movieViewModels");
        }
    }
}
