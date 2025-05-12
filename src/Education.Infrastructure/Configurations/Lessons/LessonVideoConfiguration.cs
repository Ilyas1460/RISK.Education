using Education.Persistence.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Lessons;

public class LessonVideoConfiguration : SoftDeleteEntityConfiguration<LessonVideo>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LessonVideo> builder)
    {
        builder.ToTable("lesson_videos");

        builder.Property(e => e.IsActive).IsRequired();
        builder.Property(e => e.IsFree).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.Title).IsRequired();
        builder.Property(e => e.Url).IsRequired();
    }
}
