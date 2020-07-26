using Microsoft.EntityFrameworkCore.Migrations;

namespace Questioner.Repository.Migrations
{
    public partial class AddUniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Topics_ThemeId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TopicId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers");

            migrationBuilder.CreateIndex(
                name: "UX_Topic_Name",
                table: "Topics",
                columns: new[] { "ThemeId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Theme_Name",
                table: "Themes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Question_QuestionText",
                table: "Questions",
                columns: new[] { "TopicId", "QuestionText" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Answer_AnswerText",
                table: "Answers",
                columns: new[] { "QuestionId", "AnswerText" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UX_Topic_Name",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "UX_Theme_Name",
                table: "Themes");

            migrationBuilder.DropIndex(
                name: "UX_Question_QuestionText",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "UX_Answer_AnswerText",
                table: "Answers");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ThemeId",
                table: "Topics",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TopicId",
                table: "Questions",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");
        }
    }
}
