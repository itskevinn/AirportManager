using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RoleandUsertablesnamechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemRole_Role_RoleId",
                schema: "Airport",
                table: "MenuItemRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId",
                schema: "Airport",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "Airport",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "Airport",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "Airport",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "UserRole",
                schema: "Airport",
                newName: "UserRole");

            migrationBuilder.RenameTable(
                name: "MenuItemRole",
                schema: "Airport",
                newName: "MenuItemRole");

            migrationBuilder.RenameTable(
                name: "MenuItem",
                schema: "Airport",
                newName: "MenuItem");

            migrationBuilder.RenameTable(
                name: "Flight",
                schema: "Airport",
                newName: "Flight");

            migrationBuilder.RenameTable(
                name: "City",
                schema: "Airport",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "Airline",
                schema: "Airport",
                newName: "Airline");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "Airport",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "Airport",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemRole_Roles_RoleId",
                table: "MenuItemRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Roles_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemRole_Roles_RoleId",
                table: "MenuItemRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Roles_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.EnsureSchema(
                name: "Airport");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "UserRole",
                newSchema: "Airport");

            migrationBuilder.RenameTable(
                name: "MenuItemRole",
                newName: "MenuItemRole",
                newSchema: "Airport");

            migrationBuilder.RenameTable(
                name: "MenuItem",
                newName: "MenuItem",
                newSchema: "Airport");

            migrationBuilder.RenameTable(
                name: "Flight",
                newName: "Flight",
                newSchema: "Airport");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "City",
                newSchema: "Airport");

            migrationBuilder.RenameTable(
                name: "Airline",
                newName: "Airline",
                newSchema: "Airport");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User",
                newSchema: "Airport");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role",
                newSchema: "Airport");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "Airport",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "Airport",
                table: "Role",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemRole_Role_RoleId",
                schema: "Airport",
                table: "MenuItemRole",
                column: "RoleId",
                principalSchema: "Airport",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId",
                schema: "Airport",
                table: "UserRole",
                column: "RoleId",
                principalSchema: "Airport",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "Airport",
                table: "UserRole",
                column: "UserId",
                principalSchema: "Airport",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
