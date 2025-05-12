using Education.Persistence.TestExams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.TestExams;

public class TestExamConfiguration : SoftDeleteEntityConfiguration<TestExam>
{
    protected override void ConfigureEntity(EntityTypeBuilder<TestExam> builder)
    {
        builder.ToTable("test_exams");

        builder.Property(e => e.CourseId).IsRequired(false);
        builder.Property(e => e.Description).IsRequired(false);
        builder.Property(e => e.Duration).HasDefaultValue(0).IsRequired();
        builder.Property(e => e.ExplanationUrl).IsRequired(false);
        builder.Property(e => e.IsActive).IsRequired();
        builder.Property(e => e.IsFree).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.Level).HasDefaultValue(0).IsRequired();
        builder.Property(e => e.Order).HasDefaultValue(0).IsRequired();
        builder.Property(e => e.PublishDate).IsRequired(false);
        builder.Property(e => e.Status).HasDefaultValue(0).IsRequired();
        builder.Property(e => e.Title).IsRequired();

        builder.HasOne(d => d.Course)
            .WithMany(p => p.TestExams)
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
