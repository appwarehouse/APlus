using Microsoft.EntityFrameworkCore.Migrations;

namespace APlus.DataAccess.Migrations
{
    public partial class AddTreatmentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreatmentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    TherapistTypeId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDuration = table.Column<int>(type: "int", nullable: false),
                    IsPortalVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentType_TherapistType_TherapistTypeId",
                        column: x => x.TherapistTypeId,
                        principalTable: "TherapistType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentType_TherapistTypeId",
                table: "TreatmentType",
                column: "TherapistTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmentType");
        }
    }
}
