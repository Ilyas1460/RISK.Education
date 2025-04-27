using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdMovedToBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_question_quiz_questions_questions_question_id",
                table: "question_quiz");

            migrationBuilder.DropForeignKey(
                name: "fk_question_quiz_quizzes_quizzes_quiz_id",
                table: "question_quiz");

            migrationBuilder.RenameColumn(
                name: "video_id",
                table: "videos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "topic_id",
                table: "topics",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "theory_id",
                table: "theories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "quiz_id",
                table: "quizzes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "question_id",
                table: "questions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "quizzes_quiz_id",
                table: "question_quiz",
                newName: "quizzes_id");

            migrationBuilder.RenameColumn(
                name: "questions_question_id",
                table: "question_quiz",
                newName: "questions_id");

            migrationBuilder.RenameIndex(
                name: "ix_question_quiz_quizzes_quiz_id",
                table: "question_quiz",
                newName: "ix_question_quiz_quizzes_id");

            migrationBuilder.RenameColumn(
                name: "language_id",
                table: "languages",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "courses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "answer_id",
                table: "answers",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_question_quiz_questions_questions_id",
                table: "question_quiz",
                column: "questions_id",
                principalTable: "questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_question_quiz_quizzes_quizzes_id",
                table: "question_quiz",
                column: "quizzes_id",
                principalTable: "quizzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_question_quiz_questions_questions_id",
                table: "question_quiz");

            migrationBuilder.DropForeignKey(
                name: "fk_question_quiz_quizzes_quizzes_id",
                table: "question_quiz");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "videos",
                newName: "video_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "topics",
                newName: "topic_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "theories",
                newName: "theory_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "quizzes",
                newName: "quiz_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "questions",
                newName: "question_id");

            migrationBuilder.RenameColumn(
                name: "quizzes_id",
                table: "question_quiz",
                newName: "quizzes_quiz_id");

            migrationBuilder.RenameColumn(
                name: "questions_id",
                table: "question_quiz",
                newName: "questions_question_id");

            migrationBuilder.RenameIndex(
                name: "ix_question_quiz_quizzes_id",
                table: "question_quiz",
                newName: "ix_question_quiz_quizzes_quiz_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "languages",
                newName: "language_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "courses",
                newName: "course_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "categories",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "answers",
                newName: "answer_id");

            migrationBuilder.AddForeignKey(
                name: "fk_question_quiz_questions_questions_question_id",
                table: "question_quiz",
                column: "questions_question_id",
                principalTable: "questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_question_quiz_quizzes_quizzes_quiz_id",
                table: "question_quiz",
                column: "quizzes_quiz_id",
                principalTable: "quizzes",
                principalColumn: "quiz_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
