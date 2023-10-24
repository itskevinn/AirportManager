using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Security.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 370, DateTimeKind.Local).AddTicks(777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 370, DateTimeKind.Local).AddTicks(643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 370, DateTimeKind.Local).AddTicks(470),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(4496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 370, DateTimeKind.Local).AddTicks(357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(4255));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 370, DateTimeKind.Local).AddTicks(179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 370, DateTimeKind.Local).AddTicks(62),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(3876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 369, DateTimeKind.Local).AddTicks(9865),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(3601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 369, DateTimeKind.Local).AddTicks(9722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(3398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "MenuItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 369, DateTimeKind.Local).AddTicks(9527),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(3119));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 369, DateTimeKind.Local).AddTicks(9120),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76096"),
                column: "CreatedOn",
                value: new DateTime(2023, 7, 20, 16, 39, 31, 369, DateTimeKind.Local).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76098"),
                column: "CreatedOn",
                value: new DateTime(2023, 7, 20, 16, 39, 31, 369, DateTimeKind.Local).AddTicks(8727));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(4928),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 370, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(4697),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 370, DateTimeKind.Local).AddTicks(643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(4496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 370, DateTimeKind.Local).AddTicks(470));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(4255),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 370, DateTimeKind.Local).AddTicks(357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(4055),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 370, DateTimeKind.Local).AddTicks(179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(3876),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 370, DateTimeKind.Local).AddTicks(62));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(3601),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 369, DateTimeKind.Local).AddTicks(9865));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(3398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 369, DateTimeKind.Local).AddTicks(9722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "MenuItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(3119),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 369, DateTimeKind.Local).AddTicks(9527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(2785),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 20, 16, 39, 31, 369, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76096"),
                column: "CreatedOn",
                value: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76098"),
                column: "CreatedOn",
                value: new DateTime(2023, 2, 18, 23, 28, 40, 438, DateTimeKind.Local).AddTicks(2402));
        }
    }
}
