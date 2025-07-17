using Education.Persistence.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Lessons;

public class
    LessonQuizUserQuestionAnswerLinkConfiguration : SoftDeleteEntityConfiguration<LessonQuizUserQuestionAnswerLink>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LessonQuizUserQuestionAnswerLink> builder)
    {
        builder.ToTable("lesson_quiz_user_question_answer_links");

        builder.Property(e => e.LessonQuizId).IsRequired();
        builder.Property(e => e.LessonQuizPassageToken).IsRequired();
        builder.Property(e => e.UserQuestionAnswerId).IsRequired(false);

        builder.HasOne(d => d.LessonQuiz)
            .WithMany(p => p.LessonQuizUserQuestionAnswerLinks)
            .HasForeignKey(d => d.LessonQuizId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.UserQuestionAnswer)
            .WithMany(p => p.LessonQuizUserQuestionAnswerLinks)
            .HasForeignKey(d => d.UserQuestionAnswerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
