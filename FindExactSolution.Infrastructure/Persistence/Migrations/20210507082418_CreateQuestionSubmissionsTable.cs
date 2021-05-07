using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindExactSolution.Infrastructure.Persistence.Migrations
{
    public partial class CreateQuestionSubmissionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Events_EventId",
                table: "Teams");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId1",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionSubmissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    LastSumbittedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionSubmissions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionSubmissions_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_EventId1",
                table: "Teams",
                column: "EventId1");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSubmissions_QuestionId",
                table: "QuestionSubmissions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSubmissions_TeamId",
                table: "QuestionSubmissions",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Events_EventId",
                table: "Teams",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Events_EventId1",
                table: "Teams",
                column: "EventId1",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Events_EventId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Events_EventId1",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "QuestionSubmissions");

            migrationBuilder.DropIndex(
                name: "IX_Teams_EventId1",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "EventId1",
                table: "Teams");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Events_EventId",
                table: "Teams",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
