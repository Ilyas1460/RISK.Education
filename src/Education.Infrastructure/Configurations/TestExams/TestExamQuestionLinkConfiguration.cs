using Education.Persistence.TestExams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.TestExams;

public class TestExamQuestionLinkConfiguration : SoftDeleteEntityConfiguration<TestExamQuestionLink>
{
    protected override void ConfigureEntity(EntityTypeBuilder<TestExamQuestionLink> builder)
    {
        builder.ToTable("test_exam_question_links");

        builder.Property(e => e.Order).IsRequired();
        builder.Property(e => e.QuestionId).IsRequired(false);
        builder.Property(e => e.TestExamId).IsRequired(false);

        builder.HasOne(d => d.Question)
            .WithMany(p => p.TestExamQuestionLinks)
            .HasForeignKey(d => d.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.TestExam)
            .WithMany(p => p.TestExamQuestionLinks)
            .HasForeignKey(d => d.TestExamId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
