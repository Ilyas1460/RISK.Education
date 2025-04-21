using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CategoryAndLanguageUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_answers_question_question_id",
                table: "answers");

            migrationBuilder.DropForeignKey(
                name: "fk_courses_language_language_id",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "fk_question_quiz_question_questions_question_id",
                table: "question_quiz");

            migrationBuilder.DropForeignKey(
                name: "fk_question_quiz_quiz_quizzes_quiz_id",
                table: "question_quiz");

            migrationBuilder.DropForeignKey(
                name: "fk_quizzes_topic_topic_id",
                table: "quizzes");

            migrationBuilder.DropForeignKey(
                name: "fk_theories_topic_topic_id",
                table: "theories");

            migrationBuilder.CreateIndex(
                name: "ix_languages_code",
                table: "languages",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_languages_name",
                table: "languages",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_categories_title",
                table: "categories",
                column: "title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_answers_questions_question_id",
                table: "answers",
                column: "question_id",
                principalTable: "questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_courses_languages_language_id",
                table: "courses",
                column: "language_id",
                principalTable: "languages",
                principalColumn: "language_id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "fk_quizzes_topics_topic_id",
                table: "quizzes",
                column: "topic_id",
                principalTable: "topics",
                principalColumn: "topic_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_theories_topics_topic_id",
                table: "theories",
                column: "topic_id",
                principalTable: "topics",
                principalColumn: "topic_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_answers_questions_question_id",
                table: "answers");

            migrationBuilder.DropForeignKey(
                name: "fk_courses_languages_language_id",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "fk_question_quiz_questions_questions_question_id",
                table: "question_quiz");

            migrationBuilder.DropForeignKey(
                name: "fk_question_quiz_quizzes_quizzes_quiz_id",
                table: "question_quiz");

            migrationBuilder.DropForeignKey(
                name: "fk_quizzes_topics_topic_id",
                table: "quizzes");

            migrationBuilder.DropForeignKey(
                name: "fk_theories_topics_topic_id",
                table: "theories");

            migrationBuilder.DropIndex(
                name: "ix_languages_code",
                table: "languages");

            migrationBuilder.DropIndex(
                name: "ix_languages_name",
                table: "languages");

            migrationBuilder.DropIndex(
                name: "ix_categories_title",
                table: "categories");

            migrationBuilder.AddForeignKey(
                name: "fk_answers_question_question_id",
                table: "answers",
                column: "question_id",
                principalTable: "questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_courses_language_language_id",
                table: "courses",
                column: "language_id",
                principalTable: "languages",
                principalColumn: "language_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_question_quiz_question_questions_question_id",
                table: "question_quiz",
                column: "questions_question_id",
                principalTable: "questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_question_quiz_quiz_quizzes_quiz_id",
                table: "question_quiz",
                column: "quizzes_quiz_id",
                principalTable: "quizzes",
                principalColumn: "quiz_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_quizzes_topic_topic_id",
                table: "quizzes",
                column: "topic_id",
                principalTable: "topics",
                principalColumn: "topic_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_theories_topic_topic_id",
                table: "theories",
                column: "topic_id",
                principalTable: "topics",
                principalColumn: "topic_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
