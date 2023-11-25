using Microsoft.EntityFrameworkCore.Migrations;

namespace APlus.DataAccess.Migrations
{
    public partial class AddPractitionerTypeLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Therapist",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PractitionerTypeLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    PractitionerTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PractitionerTypeLocation", x => x.Id);
                });

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
                name: "IX_LocationPractitionerTypeLocation_PractitionerTypeLocationsId",
                table: "LocationPractitionerTypeLocation",
                column: "PractitionerTypeLocationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationPractitionerTypeLocation");

            migrationBuilder.DropTable(
                name: "PractitionerTypeLocation");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Therapist",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}
