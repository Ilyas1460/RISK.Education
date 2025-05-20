using Education.Persistence.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Courses;

public class CourseConfiguration : SoftDeleteEntityConfiguration<Course>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("courses");

        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Description).IsRequired();
        builder.Property(e => e.ShortDescription).IsRequired();
        builder.Property(e => e.Slug).IsRequired(false);
        builder.Property(e => e.QuestionAnswerCount).IsRequired(false);
        builder.Property(e => e.IsActive).IsRequired().HasDefaultValue(false);
        builder.Property(e => e.CategoryId).IsRequired(false);
        builder.Property(e => e.LanguageId).IsRequired(false);

        builder.HasOne(e => e.Category)
            .WithMany(c => c.Courses)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Language)
            .WithMany(l => l.Courses)
            .HasForeignKey(e => e.LanguageId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
