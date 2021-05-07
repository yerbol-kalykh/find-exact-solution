using Microsoft.EntityFrameworkCore.Migrations;

namespace FindExactSolution.Infrastructure.Persistence.Migrations
{
    public partial class FixTypeInLastSubmittedDateTimeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastSumbittedDateTime",
                table: "QuestionSubmissions",
                newName: "LastSubmittedDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastSubmittedDateTime",
                table: "QuestionSubmissions",
                newName: "LastSumbittedDateTime");
        }
    }
}
