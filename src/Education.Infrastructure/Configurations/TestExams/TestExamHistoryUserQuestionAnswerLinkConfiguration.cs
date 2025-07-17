using Education.Persistence.TestExams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.TestExams;

public class
    TestExamHistoryUserQuestionAnswerLinkConfiguration : SoftDeleteEntityConfiguration<
    TestExamHistoryUserQuestionAnswerLink>
{
    protected override void ConfigureEntity(EntityTypeBuilder<TestExamHistoryUserQuestionAnswerLink> builder)
    {
        builder.ToTable("test_exam_history_user_question_answer_links");

        builder.Property(e => e.TestExamHistoryId).IsRequired();
        builder.Property(e => e.UserQuestionAnswerId).IsRequired(false);

        builder.HasOne(d => d.TestExamHistory)
            .WithMany(p => p.TestExamHistoryUserQuestionAnswerLinks)
            .HasForeignKey(d => d.TestExamHistoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.UserQuestionAnswer)
            .WithMany(p => p.TestExamHistoryUserQuestionAnswerLinks)
            .HasForeignKey(d => d.UserQuestionAnswerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
