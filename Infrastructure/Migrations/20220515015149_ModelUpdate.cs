using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Airport",
                table: "UserRole",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "Airport",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "Airport",
                table: "UserRole",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                schema: "Airport",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                schema: "Airport",
                table: "UserRole",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "Airport",
                table: "UserRole",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Airport",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "Airport",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Airport",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                schema: "Airport",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Airport",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "Airport",
                table: "UserRole");
        }
    }
}
