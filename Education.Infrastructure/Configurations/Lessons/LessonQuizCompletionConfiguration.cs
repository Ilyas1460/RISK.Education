using Education.Persistence.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Lessons;

public class LessonQuizCompletionConfiguration : SoftDeleteEntityConfiguration<LessonQuizCompletion>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LessonQuizCompletion> builder)
    {
        builder.ToTable("lesson_quiz_completions");

        builder.Property(e => e.LessonQuizId).IsRequired(false);
        builder.Property(e => e.UserId).IsRequired(false);

        builder.HasOne(d => d.LessonQuiz)
            .WithMany(p => p.LessonQuizCompletions)
            .HasForeignKey(d => d.LessonQuizId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.User)
            .WithMany(p => p.LessonQuizCompletions)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
