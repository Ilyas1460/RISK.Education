using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CategoryAndLanguageUniqueConstraintsWhenDeletetAtIsNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_languages_code",
                table: "languages");

            migrationBuilder.DropIndex(
                name: "ix_languages_name",
                table: "languages");

            migrationBuilder.DropIndex(
                name: "ix_categories_title",
                table: "categories");

            migrationBuilder.CreateIndex(
                name: "ix_languages_code",
                table: "languages",
                column: "code",
                unique: true,
                filter: "\"deleted_at\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "ix_languages_name",
                table: "languages",
                column: "name",
                unique: true,
                filter: "\"deleted_at\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "ix_categories_title",
                table: "categories",
                column: "title",
                unique: true,
                filter: "\"deleted_at\" IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_languages_code",
                table: "languages");

            migrationBuilder.DropIndex(
                name: "ix_languages_name",
                table: "languages");

            migrationBuilder.DropIndex(
                name: "ix_categories_title",
                table: "categories");

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
        }
    }
}
