using Microsoft.EntityFrameworkCore.Migrations;

namespace APlus.DataAccess.Migrations
{
    public partial class AddTherapistTypesToTractitionerLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PractitionerTypeLocationId",
                table: "TherapistType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TherapistType_PractitionerTypeLocationId",
                table: "TherapistType",
                column: "PractitionerTypeLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TherapistType_PractitionerTypeLocation_PractitionerTypeLocationId",
                table: "TherapistType",
                column: "PractitionerTypeLocationId",
                principalTable: "PractitionerTypeLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TherapistType_PractitionerTypeLocation_PractitionerTypeLocationId",
                table: "TherapistType");

            migrationBuilder.DropIndex(
                name: "IX_TherapistType_PractitionerTypeLocationId",
                table: "TherapistType");

            migrationBuilder.DropColumn(
                name: "PractitionerTypeLocationId",
                table: "TherapistType");
        }
    }
}
