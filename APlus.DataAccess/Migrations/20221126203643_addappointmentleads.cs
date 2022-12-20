using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APlus.DataAccess.Migrations
{
    public partial class addappointmentleads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "PortalVisible",
            //    table: "TherapistType");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPortalVisible",
                table: "TherapistType",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payload = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPortalVisible",
                table: "TherapistType",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "PortalVisible",
            //    table: "TherapistType",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);
        }
    }
}