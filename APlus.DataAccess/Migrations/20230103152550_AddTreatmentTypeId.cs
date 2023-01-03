using Microsoft.EntityFrameworkCore.Migrations;

namespace APlus.DataAccess.Migrations
{
    public partial class AddTreatmentTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentType_TherapistType_TherapistTypeId",
                table: "TreatmentType");

            migrationBuilder.AlterColumn<string>(
                name: "TreatmentTypeName",
                table: "TreatmentType",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPortalVisible",
                table: "TreatmentType",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TreatmentType",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentTypeId",
                table: "TherapistType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TherapistType_TreatmentType",
                table: "TreatmentType",
                column: "TherapistTypeId",
                principalTable: "TherapistType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TherapistType_TreatmentType",
                table: "TreatmentType");

            migrationBuilder.DropColumn(
                name: "TreatmentTypeId",
                table: "TherapistType");

            migrationBuilder.AlterColumn<string>(
                name: "TreatmentTypeName",
                table: "TreatmentType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPortalVisible",
                table: "TreatmentType",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TreatmentType",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((1))");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentType_TherapistType_TherapistTypeId",
                table: "TreatmentType",
                column: "TherapistTypeId",
                principalTable: "TherapistType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
