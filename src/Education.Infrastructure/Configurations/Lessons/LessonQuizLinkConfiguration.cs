using Education.Persistence.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Lessons;

public class LessonQuizLinkConfiguration : SoftDeleteEntityConfiguration<LessonQuizLink>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LessonQuizLink> builder)
    {
        builder.ToTable("lesson_quiz_links");

        builder.Property(e => e.LessonQuizId).IsRequired(false);
        builder.Property(e => e.LessonId).IsRequired(false);

        builder.HasOne(d => d.Lesson)
            .WithMany(p => p.LessonQuizLinks)
            .HasForeignKey(d => d.LessonId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.LessonQuiz)
            .WithMany(p => p.LessonQuizLinks)
            .HasForeignKey(d => d.LessonQuizId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
