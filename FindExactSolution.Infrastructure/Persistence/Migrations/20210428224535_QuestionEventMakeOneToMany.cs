using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindExactSolution.Infrastructure.Persistence.Migrations
{
    public partial class QuestionEventMakeOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventQuestion");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_EventId",
                table: "Questions",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Events_EventId",
                table: "Questions",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Events_EventId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_EventId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Questions");

            migrationBuilder.CreateTable(
                name: "EventQuestion",
                columns: table => new
                {
                    EventsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventQuestion", x => new { x.EventsId, x.QuestionsId });
                    table.ForeignKey(
                        name: "FK_EventQuestion_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventQuestion_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventQuestion_QuestionsId",
                table: "EventQuestion",
                column: "QuestionsId");
        }
    }
}
