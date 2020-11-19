using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetApp.Web.Migrations
{
    public partial class ModifiedCategoryPhotoPathcolumnadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Category");
        }
    }
}
