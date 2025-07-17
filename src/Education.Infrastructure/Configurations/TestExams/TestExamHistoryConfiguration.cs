using Education.Persistence.TestExams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.TestExams;

public class TestExamHistoryConfiguration : SoftDeleteEntityConfiguration<TestExamHistory>
{
    protected override void ConfigureEntity(EntityTypeBuilder<TestExamHistory> builder)
    {
        builder.ToTable("test_exam_history");

        builder.Property(e => e.EndTime).IsRequired(false);
        builder.Property(e => e.StartTime).HasDefaultValueSql("'-infinity'::timestamp with time zone").IsRequired();
        builder.Property(e => e.TestExamId).IsRequired(false);
        builder.Property(e => e.TestExamPassageToken).IsRequired();
        builder.Property(e => e.UserId).IsRequired(false);

        builder.HasOne(d => d.TestExam)
            .WithMany(p => p.TestExamHistories)
            .HasForeignKey(d => d.TestExamId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.User)
            .WithMany(p => p.TestExamHistories)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
