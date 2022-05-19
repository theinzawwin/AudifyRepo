using Microsoft.EntityFrameworkCore.Migrations;

namespace AudifyProject.Migrations
{
    public partial class AddProfileAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Profile",
                table: "Author",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profile",
                table: "Author");
        }
    }
}
