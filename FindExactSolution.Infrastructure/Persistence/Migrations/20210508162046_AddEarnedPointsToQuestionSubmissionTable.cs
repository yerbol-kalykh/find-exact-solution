using Microsoft.EntityFrameworkCore.Migrations;

namespace FindExactSolution.Infrastructure.Persistence.Migrations
{
    public partial class AddEarnedPointsToQuestionSubmissionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "QuestionSubmissions",
                newName: "TeamAnswer");

            migrationBuilder.AddColumn<int>(
                name: "EarnedPoints",
                table: "QuestionSubmissions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EarnedPoints",
                table: "QuestionSubmissions");

            migrationBuilder.RenameColumn(
                name: "TeamAnswer",
                table: "QuestionSubmissions",
                newName: "Answer");
        }
    }
}
