using Microsoft.EntityFrameworkCore.Migrations;

namespace APlus.DataAccess.Migrations
{
    public partial class FixPractitionerTypeLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TherapistType_PractitionerTypeLocation_PractitionerTypeLocationId",
                table: "TherapistType");

            migrationBuilder.DropTable(
                name: "LocationPractitionerTypeLocation");

            migrationBuilder.DropIndex(
                name: "IX_TherapistType_PractitionerTypeLocationId",
                table: "TherapistType");

            migrationBuilder.DropColumn(
                name: "PractitionerTypeLocationId",
                table: "TherapistType");

            migrationBuilder.AddColumn<int>(
                name: "TherapistTypeId",
                table: "PractitionerTypeLocation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PractitionerTypeLocation_LocationId",
                table: "PractitionerTypeLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PractitionerTypeLocation_TherapistTypeId",
                table: "PractitionerTypeLocation",
                column: "TherapistTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PractitionerTypeLocation_Location_LocationId",
                table: "PractitionerTypeLocation",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PractitionerTypeLocation_TherapistType_TherapistTypeId",
                table: "PractitionerTypeLocation",
                column: "TherapistTypeId",
                principalTable: "TherapistType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PractitionerTypeLocation_Location_LocationId",
                table: "PractitionerTypeLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_PractitionerTypeLocation_TherapistType_TherapistTypeId",
                table: "PractitionerTypeLocation");

            migrationBuilder.DropIndex(
                name: "IX_PractitionerTypeLocation_LocationId",
                table: "PractitionerTypeLocation");

            migrationBuilder.DropIndex(
                name: "IX_PractitionerTypeLocation_TherapistTypeId",
                table: "PractitionerTypeLocation");

            migrationBuilder.DropColumn(
                name: "TherapistTypeId",
                table: "PractitionerTypeLocation");

            migrationBuilder.AddColumn<int>(
                name: "PractitionerTypeLocationId",
                table: "TherapistType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocationPractitionerTypeLocation",
                columns: table => new
                {
                    LocationsId = table.Column<int>(type: "int", nullable: false),
                    PractitionerTypeLocationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationPractitionerTypeLocation", x => new { x.LocationsId, x.PractitionerTypeLocationsId });
                    table.ForeignKey(
                        name: "FK_LocationPractitionerTypeLocation_Location_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationPractitionerTypeLocation_PractitionerTypeLocation_PractitionerTypeLocationsId",
                        column: x => x.PractitionerTypeLocationsId,
                        principalTable: "PractitionerTypeLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TherapistType_PractitionerTypeLocationId",
                table: "TherapistType",
                column: "PractitionerTypeLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationPractitionerTypeLocation_PractitionerTypeLocationsId",
                table: "LocationPractitionerTypeLocation",
                column: "PractitionerTypeLocationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TherapistType_PractitionerTypeLocation_PractitionerTypeLocationId",
                table: "TherapistType",
                column: "PractitionerTypeLocationId",
                principalTable: "PractitionerTypeLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
