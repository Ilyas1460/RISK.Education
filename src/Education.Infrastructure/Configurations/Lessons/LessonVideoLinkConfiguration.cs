using Education.Persistence.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Lessons;

public class LessonVideoLinkConfiguration : SoftDeleteEntityConfiguration<LessonVideoLink>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LessonVideoLink> builder)
    {
        builder.ToTable("lesson_video_links");

        builder.Property(e => e.LessonId).IsRequired(false);
        builder.Property(e => e.LessonVideoId).IsRequired(false);

        builder.HasOne(d => d.Lesson)
            .WithMany(p => p.LessonVideoLinks)
            .HasForeignKey(d => d.LessonId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.LessonVideo)
            .WithMany(p => p.LessonVideoLinks)
            .HasForeignKey(d => d.LessonVideoId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
