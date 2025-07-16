using Education.Persistence.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Lessons;

public class LessonTheoryConfiguration : SoftDeleteEntityConfiguration<LessonTheory>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LessonTheory> builder)
    {
        builder.ToTable("lesson_theories");

        builder.Property(e => e.Content).IsRequired();
        builder.Property(e => e.IsActive).IsRequired();
        builder.Property(e => e.IsFree).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.Title).IsRequired();
    }
}
