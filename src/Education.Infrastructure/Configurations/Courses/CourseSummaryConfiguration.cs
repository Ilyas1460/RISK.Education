using Education.Persistence.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Courses;

public class CourseSummaryConfiguration : IEntityTypeConfiguration<CourseSummary>
{
    public void Configure(EntityTypeBuilder<CourseSummary> builder)
    {
        builder
            .HasNoKey()
            .ToView("course_summary");
    }
}
