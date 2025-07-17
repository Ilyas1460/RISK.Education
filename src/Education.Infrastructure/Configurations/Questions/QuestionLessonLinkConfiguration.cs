using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class QuestionLessonLinkConfiguration : SoftDeleteEntityConfiguration<QuestionLessonLink>
{
    protected override void ConfigureEntity(EntityTypeBuilder<QuestionLessonLink> builder)
    {
        builder.ToTable("question_lesson_links");

        builder.Property(e => e.LessonId).IsRequired(false);
        builder.Property(e => e.QuestionId).IsRequired(false);

        builder.HasOne(d => d.Lesson)
            .WithMany(p => p.QuestionLessonLinks)
            .HasForeignKey(d => d.LessonId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.Question)
            .WithMany(p => p.QuestionLessonLinks)
            .HasForeignKey(d => d.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
