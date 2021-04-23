using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindExactSolution.Infrastructure.Persistence.Migrations
{
    public partial class AddStartedAndEndDateTimeToEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Events",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "StartDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "StartDateTime",
                table: "Events",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Events",
                newName: "DeleteDate");
        }
    }
}
