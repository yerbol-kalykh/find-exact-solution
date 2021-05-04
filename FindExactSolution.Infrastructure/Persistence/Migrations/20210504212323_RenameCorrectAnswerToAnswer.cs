using Microsoft.EntityFrameworkCore.Migrations;

namespace FindExactSolution.Infrastructure.Persistence.Migrations
{
    public partial class RenameCorrectAnswerToAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CorrectAnswer",
                table: "Questions",
                newName: "Answer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "Questions",
                newName: "CorrectAnswer");
        }
    }
}
