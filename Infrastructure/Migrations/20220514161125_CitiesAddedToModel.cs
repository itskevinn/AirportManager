using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CitiesAddedToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_City_DepartureCityId",
                schema: "Airport",
                table: "Flight",
                column: "DepartureCityId",
                principalSchema: "Airport",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_City_DestinyCityId",
                schema: "Airport",
                table: "Flight",
                column: "DestinyCityId",
                principalSchema: "Airport",
                principalTable: "City",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_City_DepartureCityId",
                schema: "Airport",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_City_DestinyCityId",
                schema: "Airport",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_DepartureCityId",
                schema: "Airport",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_DestinyCityId",
                schema: "Airport",
                table: "Flight");
        }
    }
}
