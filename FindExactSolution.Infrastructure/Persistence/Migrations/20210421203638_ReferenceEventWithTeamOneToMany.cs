using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindExactSolution.Infrastructure.Persistence.Migrations
{
    public partial class ReferenceEventWithTeamOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventTeam");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_EventId",
                table: "Teams",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Events_EventId",
                table: "Teams",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Events_EventId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_EventId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Teams");

            migrationBuilder.CreateTable(
                name: "EventTeam",
                columns: table => new
                {
                    EventsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTeam", x => new { x.EventsId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_EventTeam_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTeam_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventTeam_TeamsId",
                table: "EventTeam",
                column: "TeamsId");
        }
    }
}
