using Education.Persistence.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Courses;

public class UserCourseConfiguration : SoftDeleteEntityConfiguration<UserCourse>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserCourse> builder)
    {
        builder.ToTable("user_courses");

        builder.Property(e => e.CourseAccessType).IsRequired();
        builder.Property(e => e.CourseId).IsRequired(false);
        builder.Property(e => e.ExpireTime).IsRequired();
        builder.Property(e => e.StartTime).IsRequired();
        builder.Property(e => e.UserId).IsRequired(false);

        builder.HasOne(d => d.Course)
            .WithMany(p => p.UserCourses)
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.User)
            .WithMany(p => p.UserCourses)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
