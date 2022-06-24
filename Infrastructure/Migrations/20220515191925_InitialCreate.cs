using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Airport");

            migrationBuilder.CreateTable(
                name: "Airline",
                schema: "Airport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "Airport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                schema: "Airport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouterLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Airport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Airport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pazzword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                schema: "Airport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AirlineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckInTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckOutTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinyCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Airline_AirlineId",
                        column: x => x.AirlineId,
                        principalSchema: "Airport",
                        principalTable: "Airline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_City_DepartureCityId",
                        column: x => x.DepartureCityId,
                        principalSchema: "Airport",
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flight_City_DestinyCityId",
                        column: x => x.DestinyCityId,
                        principalSchema: "Airport",
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuItemRole",
                schema: "Airport",
                columns: table => new
                {
                    MenuItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemRole", x => new { x.RoleId, x.MenuItemId });
                    table.ForeignKey(
                        name: "FK_MenuItemRole_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalSchema: "Airport",
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Airport",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Airport",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Airport",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Airport",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Airport",
                table: "MenuItem",
                columns: new[] { "Id", "CreatedBy", "Icon", "Label", "Order", "RouterLink", "Status", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("012fff70-84e2-4962-84a3-3b7833bb71fb"), "AutoGenerated", "fa-solid fa-house", "Inicio", 0, "home", true, "AutoGenerated" },
                    { new Guid("0b63d953-fce2-4538-ba1d-0537680130ae"), "AutoGenerated", "fa-solid fa-city", "Ciudades", 3, "cities", true, "AutoGenerated" },
                    { new Guid("504731d4-0a34-41d5-9b0b-0611b3f76096"), "AutoGenerated", "fa-solid fa-plane-departure", "Vuelos", 1, "flights", true, "AutoGenerated" },
                    { new Guid("a10dafa8-c540-4509-a08f-d8fe5ded1995"), "AutoGenerated", "fa-solid fa-plane", "Aereolíneas", 2, "airlines", true, "AutoGenerated" }
                });

            migrationBuilder.InsertData(
                schema: "Airport",
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "RoleName", "Status", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4a77cee4-5cfa-4c90-b41a-08da36159111"), "AutoGenerated", "User", true, "AutoGenerated" },
                    { new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"), "AutoGenerated", "Admin", true, "AutoGenerated" }
                });

            migrationBuilder.InsertData(
                schema: "Airport",
                table: "User",
                columns: new[] { "Id", "CreatedBy", "Name", "pazzword", "Status", "UpdatedBy", "Username" },
                values: new object[,]
                {
                    { new Guid("4a77cee4-5cfa-4c90-b41a-08da36159120"), "AutoGenerated", "Kevin Pontón", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", true, "AutoGenerated", "Admin" },
                    { new Guid("c82a18c6-e473-4976-5f2e-08da35e4eb6f"), "AutoGenerated", "Usuario", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", true, "AutoGenerated", "User" }
                });

            migrationBuilder.InsertData(
                schema: "Airport",
                table: "MenuItemRole",
                columns: new[] { "MenuItemId", "RoleId", "CreatedBy", "Id", "Status", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("012fff70-84e2-4962-84a3-3b7833bb71fb"), new Guid("4a77cee4-5cfa-4c90-b41a-08da36159111"), "AutoGenerated", new Guid("c82a18c6-e473-4976-5f2e-08da35e4eb8b"), true, "AutoGenerated" },
                    { new Guid("504731d4-0a34-41d5-9b0b-0611b3f76096"), new Guid("4a77cee4-5cfa-4c90-b41a-08da36159111"), "AutoGenerated", new Guid("c82a18c6-e473-4976-5f2e-08da35e4eb8a"), true, "AutoGenerated" },
                    { new Guid("012fff70-84e2-4962-84a3-3b7833bb71fb"), new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"), "AutoGenerated", new Guid("c82a18c6-e473-4976-5f2e-08da35e4eb8e"), true, "AutoGenerated" },
                    { new Guid("0b63d953-fce2-4538-ba1d-0537680130ae"), new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"), "AutoGenerated", new Guid("c82a18c6-e473-4976-5f2e-08da35e4ebef"), true, "AutoGenerated" },
                    { new Guid("504731d4-0a34-41d5-9b0b-0611b3f76096"), new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"), "AutoGenerated", new Guid("c82a18c6-e473-4976-5f2e-08da35e4ebfe"), true, "AutoGenerated" },
                    { new Guid("a10dafa8-c540-4509-a08f-d8fe5ded1995"), new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"), "AutoGenerated", new Guid("c82a18c6-e473-4976-5f2e-08da35e4eb1a"), true, "AutoGenerated" }
                });

            migrationBuilder.InsertData(
                schema: "Airport",
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "Id", "Status", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4a77cee4-5cfa-4c90-b41a-08da36159111"), new Guid("c82a18c6-e473-4976-5f2e-08da35e4eb6f"), "AutoGenerated", new Guid("bf1de1aa-fc78-4b92-6942-09da3e131298"), true, "AutoGenerated" },
                    { new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"), new Guid("4a77cee4-5cfa-4c90-b41a-08da36159120"), "AutoGenerated", new Guid("bf1de1aa-fc78-4b92-6942-09da36131298"), true, "AutoGenerated" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineId",
                schema: "Airport",
                table: "Flight",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DepartureCityId",
                schema: "Airport",
                table: "Flight",
                column: "DepartureCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DestinyCityId",
                schema: "Airport",
                table: "Flight",
                column: "DestinyCityId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRole_MenuItemId",
                schema: "Airport",
                table: "MenuItemRole",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                schema: "Airport",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight",
                schema: "Airport");

            migrationBuilder.DropTable(
                name: "MenuItemRole",
                schema: "Airport");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Airport");

            migrationBuilder.DropTable(
                name: "Airline",
                schema: "Airport");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Airport");

            migrationBuilder.DropTable(
                name: "MenuItem",
                schema: "Airport");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Airport");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Airport");
        }
    }
}
