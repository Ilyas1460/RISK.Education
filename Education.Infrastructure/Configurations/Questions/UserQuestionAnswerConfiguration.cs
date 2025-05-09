using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class UserQuestionAnswerConfiguration : SoftDeleteEntityConfiguration<UserQuestionAnswer>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserQuestionAnswer> builder)
    {
        builder.ToTable("user_question_answers");

        builder.Property(e => e.AnsweredCorrect).IsRequired();
        builder.Property(e => e.QuestionAnswerEntityId).IsRequired(false);
        builder.Property(e => e.QuestionId).IsRequired(false);
        builder.Property(e => e.UserId).IsRequired(false);

        builder.HasOne(d => d.QuestionAnswerEntity)
            .WithMany(p => p.UserQuestionAnswers)
            .HasForeignKey(d => d.QuestionAnswerEntityId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.Question)
            .WithMany(p => p.UserQuestionAnswers)
            .HasForeignKey(d => d.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.User)
            .WithMany(p => p.UserQuestionAnswers)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
