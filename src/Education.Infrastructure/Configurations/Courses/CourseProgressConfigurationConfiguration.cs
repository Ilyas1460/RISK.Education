using Education.Persistence.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Courses;

public class CourseProgressConfigurationConfiguration : SoftDeleteEntityConfiguration<CourseProgressConfiguration>
{
    protected override void ConfigureEntity(EntityTypeBuilder<CourseProgressConfiguration> builder)
    {
        builder.ToTable("course_progress_configuration");

        builder.Property(e => e.Component).IsRequired();
        builder.Property(e => e.Weight).IsRequired();
        builder.Property(e => e.LevelId).IsRequired(false);

        builder.HasOne(e => e.Level)
            .WithMany(l => l.CourseProgressConfigurations)
            .HasForeignKey(e => e.LevelId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
