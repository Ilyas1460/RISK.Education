using Education.Persistence.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Lessons;

public class LessonQuizQuestionLinkConfiguration : SoftDeleteEntityConfiguration<LessonQuizQuestionLink>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LessonQuizQuestionLink> builder)
    {
        builder.ToTable("lesson_quiz_question_links");

        builder.Property(e => e.LessonQuizId).IsRequired(false);
        builder.Property(e => e.QuestionId).IsRequired(false);

        builder.HasOne(d => d.LessonQuiz)
            .WithMany(p => p.LessonQuizQuestionLinks)
            .HasForeignKey(d => d.LessonQuizId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.Question)
            .WithMany(p => p.LessonQuizQuestionLinks)
            .HasForeignKey(d => d.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
