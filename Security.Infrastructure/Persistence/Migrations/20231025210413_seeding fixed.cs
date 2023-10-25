using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Security.Infrastructure.Persistence.Migrations
{
    public partial class seedingfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6628),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(6061));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6538),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(5757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6445),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(5195));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6341),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6244),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6119),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(4077));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6011),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(3705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(3136));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "MenuItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5754),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5556),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76096"),
                columns: new[] { "CreatedOn", "Label", "RouterLink" },
                values: new object[] { new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5379), "Vuelos", "flights" });

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76098"),
                column: "CreatedOn",
                value: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5402));

            migrationBuilder.InsertData(
                table: "MenuItem",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Icon", "Label", "LastModifiedBy", "Order", "RouterLink", "Status" },
                values: new object[,]
                {
                    { new Guid("504731d4-0a34-41d5-9b0b-0611b3f76000"), "AutoGenerated", new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5395), "fa-solid fa-building", "Aerolíneas", "AutoGenerated", 1, "airlines", true },
                    { new Guid("504731d4-0a34-41d5-9b0b-0611b3f76097"), "AutoGenerated", new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5392), "fa-solid fa-city", "Ciudades", "AutoGenerated", 1, "cities", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76000"));

            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76097"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(6061),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(5757),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(5195),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(4930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6341));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(4580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6244));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(4077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(3705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6011));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(3136),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "MenuItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(2716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(1925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76096"),
                columns: new[] { "CreatedOn", "Label", "RouterLink" },
                values: new object[] { new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(1212), "Tickets", "tickets" });

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76098"),
                column: "CreatedOn",
                value: new DateTime(2023, 6, 17, 18, 3, 43, 374, DateTimeKind.Local).AddTicks(1262));
        }
    }
}
