using Microsoft.EntityFrameworkCore.Migrations;

namespace APlus.DataAccess.Migrations
{
    public partial class FixDoubleTherapistTypeIdColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PractitionerTypeLocation_TherapistType_TherapistTypeId",
                table: "PractitionerTypeLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentType_TherapistType_TherapistTypeId1",
                table: "TreatmentType");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentType_TherapistTypeId1",
                table: "TreatmentType");

            migrationBuilder.DropColumn(
                name: "TherapistTypeId1",
                table: "TreatmentType");

            migrationBuilder.DropColumn(
                name: "TreatmentTypeId",
                table: "TherapistType");

            migrationBuilder.DropColumn(
                name: "PractitionerTypeId",
                table: "PractitionerTypeLocation");

            migrationBuilder.AlterColumn<int>(
                name: "TherapistTypeId",
                table: "PractitionerTypeLocation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentType_TherapistTypeId",
                table: "TreatmentType",
                column: "TherapistTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PractitionerTypeLocation_TherapistType_TherapistTypeId",
                table: "PractitionerTypeLocation",
                column: "TherapistTypeId",
                principalTable: "TherapistType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentType_TherapistType_TherapistTypeId",
                table: "TreatmentType",
                column: "TherapistTypeId",
                principalTable: "TherapistType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PractitionerTypeLocation_TherapistType_TherapistTypeId",
                table: "PractitionerTypeLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentType_TherapistType_TherapistTypeId",
                table: "TreatmentType");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentType_TherapistTypeId",
                table: "TreatmentType");

            migrationBuilder.AddColumn<int>(
                name: "TherapistTypeId1",
                table: "TreatmentType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentTypeId",
                table: "TherapistType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TherapistTypeId",
                table: "PractitionerTypeLocation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PractitionerTypeId",
                table: "PractitionerTypeLocation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentType_TherapistTypeId1",
                table: "TreatmentType",
                column: "TherapistTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PractitionerTypeLocation_TherapistType_TherapistTypeId",
                table: "PractitionerTypeLocation",
                column: "TherapistTypeId",
                principalTable: "TherapistType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentType_TherapistType_TherapistTypeId1",
                table: "TreatmentType",
                column: "TherapistTypeId1",
                principalTable: "TherapistType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
