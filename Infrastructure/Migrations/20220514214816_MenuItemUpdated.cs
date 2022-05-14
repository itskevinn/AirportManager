using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class MenuItemUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "Airport",
                table: "MenuItem",
                newName: "RouterLink");

            migrationBuilder.RenameColumn(
                name: "Route",
                schema: "Airport",
                table: "MenuItem",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "IconClass",
                schema: "Airport",
                table: "MenuItem",
                newName: "Icon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RouterLink",
                schema: "Airport",
                table: "MenuItem",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Label",
                schema: "Airport",
                table: "MenuItem",
                newName: "Route");

            migrationBuilder.RenameColumn(
                name: "Icon",
                schema: "Airport",
                table: "MenuItem",
                newName: "IconClass");
        }
    }
}
