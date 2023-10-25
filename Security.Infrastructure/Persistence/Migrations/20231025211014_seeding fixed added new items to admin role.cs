using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Security.Infrastructure.Persistence.Migrations
{
    public partial class seedingfixedaddednewitemstoadminrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3557),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3460),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6341));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6244));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3017),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6011));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(2842),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "MenuItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(2690),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(2526),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76000"),
                column: "CreatedOn",
                value: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76096"),
                column: "CreatedOn",
                value: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76097"),
                column: "CreatedOn",
                value: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76098"),
                column: "CreatedOn",
                value: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(2363));

            migrationBuilder.InsertData(
                table: "MenuItemRole",
                columns: new[] { "MenuItemId", "RoleId", "CreatedBy", "Id", "LastModifiedBy", "Status" },
                values: new object[,]
                {
                    { new Guid("504731d4-0a34-41d5-9b0b-0611b3f76000"), new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"), "AutoGenerated", new Guid("c82a18c6-e473-4976-5f2e-08da35e4ebbb"), "AutoGenerated", true },
                    { new Guid("504731d4-0a34-41d5-9b0b-0611b3f76097"), new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"), "AutoGenerated", new Guid("c82a18c6-e473-4976-5f2e-08da35e4ebaa"), "AutoGenerated", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItemRole",
                keyColumns: new[] { "MenuItemId", "RoleId" },
                keyValues: new object[] { new Guid("504731d4-0a34-41d5-9b0b-0611b3f76000"), new Guid("bf1de1aa-fc78-4b92-6942-08da36131198") });

            migrationBuilder.DeleteData(
                table: "MenuItemRole",
                keyColumns: new[] { "MenuItemId", "RoleId" },
                keyValues: new object[] { new Guid("504731d4-0a34-41d5-9b0b-0611b3f76097"), new Guid("bf1de1aa-fc78-4b92-6942-08da36131198") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6628),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3674));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6538),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3557));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6445),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3460));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6341),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6244),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6119),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(6011),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(3017));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItemRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(2842));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "MenuItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5754),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(2690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5556),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 16, 10, 14, 641, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76000"),
                column: "CreatedOn",
                value: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76096"),
                column: "CreatedOn",
                value: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76097"),
                column: "CreatedOn",
                value: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "MenuItem",
                keyColumn: "Id",
                keyValue: new Guid("504731d4-0a34-41d5-9b0b-0611b3f76098"),
                column: "CreatedOn",
                value: new DateTime(2023, 10, 25, 16, 4, 13, 524, DateTimeKind.Local).AddTicks(5402));
        }
    }
}
