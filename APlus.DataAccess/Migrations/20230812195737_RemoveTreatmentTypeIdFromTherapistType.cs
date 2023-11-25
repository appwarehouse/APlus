using Microsoft.EntityFrameworkCore.Migrations;

namespace APlus.DataAccess.Migrations
{
    public partial class RemoveTreatmentTypeIdFromTherapistType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TherapistType_TreatmentType",
                table: "TreatmentType");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentType_TherapistTypeId",
                table: "TreatmentType");

            migrationBuilder.AddColumn<int>(
                name: "TherapistTypeId1",
                table: "TreatmentType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentType_TherapistTypeId1",
                table: "TreatmentType",
                column: "TherapistTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentType_TherapistType_TherapistTypeId1",
                table: "TreatmentType",
                column: "TherapistTypeId1",
                principalTable: "TherapistType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentType_TherapistType_TherapistTypeId1",
                table: "TreatmentType");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentType_TherapistTypeId1",
                table: "TreatmentType");

            migrationBuilder.DropColumn(
                name: "TherapistTypeId1",
                table: "TreatmentType");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentType_TherapistTypeId",
                table: "TreatmentType",
                column: "TherapistTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TherapistType_TreatmentType",
                table: "TreatmentType",
                column: "TherapistTypeId",
                principalTable: "TherapistType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
