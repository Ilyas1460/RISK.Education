using Education.Persistence.TestExams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.TestExams;

public class TestExamTagConfiguration : SoftDeleteEntityConfiguration<TestExamTag>
{
    protected override void ConfigureEntity(EntityTypeBuilder<TestExamTag> builder)
    {
        builder.ToTable("test_exam_tags");

        builder.Property(e => e.TagId).IsRequired();
        builder.Property(e => e.TestExamId).IsRequired();

        builder.HasOne(d => d.Tag)
            .WithMany(p => p.TestExamTags)
            .HasForeignKey(d => d.TagId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.TestExam)
            .WithMany(p => p.TestExamTags)
            .HasForeignKey(d => d.TestExamId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
