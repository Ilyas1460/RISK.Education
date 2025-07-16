using Education.Persistence.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Lessons;

public class LessonVideoCompletionConfiguration : SoftDeleteEntityConfiguration<LessonVideoCompletion>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LessonVideoCompletion> builder)
    {
        builder.ToTable("lesson_video_completions");

        builder.Property(e => e.LessonVideoId).IsRequired(false);
        builder.Property(e => e.UserId).IsRequired(false);

        builder.HasOne(d => d.LessonVideo)
            .WithMany(p => p.LessonVideoCompletions)
            .HasForeignKey(d => d.LessonVideoId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.User)
            .WithMany(p => p.LessonVideoCompletions)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
