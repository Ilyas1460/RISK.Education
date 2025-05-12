using Education.Persistence.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Courses;

public class CourseProgressLevelConfiguration : SoftDeleteEntityConfiguration<CourseProgressLevel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<CourseProgressLevel> builder)
    {
        builder.ToTable("course_progress_level");

        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Order).IsRequired();
    }
}
