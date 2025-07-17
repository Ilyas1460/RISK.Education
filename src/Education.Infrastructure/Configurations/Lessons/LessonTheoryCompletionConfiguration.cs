using Education.Persistence.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Lessons;

public class LessonTheoryCompletionConfiguration : SoftDeleteEntityConfiguration<LessonTheoryCompletion>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LessonTheoryCompletion> builder)
    {
        builder.ToTable("lesson_theory_completions");

        builder.Property(e => e.LessonTheoryId).IsRequired(false);
        builder.Property(e => e.UserId).IsRequired(false);

        builder.HasOne(d => d.LessonTheory)
            .WithMany(p => p.LessonTheoryCompletions)
            .HasForeignKey(d => d.LessonTheoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.User)
            .WithMany(p => p.LessonTheoryCompletions)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
