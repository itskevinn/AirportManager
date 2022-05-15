using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class MenuItemModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Airport",
                table: "MenuItemRole",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "Airport",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "Airport",
                table: "MenuItemRole",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                schema: "Airport",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "Airport",
                table: "MenuItemRole",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "Airport",
                table: "MenuItemRole",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Airport",
                table: "MenuItemRole");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "Airport",
                table: "MenuItemRole");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Airport",
                table: "MenuItemRole");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                schema: "Airport",
                table: "MenuItemRole");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Airport",
                table: "MenuItemRole");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "Airport",
                table: "MenuItemRole");
        }
    }
}
