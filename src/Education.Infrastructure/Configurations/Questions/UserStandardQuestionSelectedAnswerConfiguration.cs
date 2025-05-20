using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class
    UserStandardQuestionSelectedAnswerConfiguration : SoftDeleteEntityConfiguration<UserStandardQuestionSelectedAnswer>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserStandardQuestionSelectedAnswer> builder)
    {
        builder.ToTable("user_standard_question_selected_answers");

        builder.Property(e => e.UserQuestionAnswerId).IsRequired(false);
        builder.Property(e => e.UserSelectedAnswerId).IsRequired();

        builder.HasOne(d => d.UserQuestionAnswer)
            .WithMany(p => p.UserStandardQuestionSelectedAnswers)
            .HasForeignKey(d => d.UserQuestionAnswerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.UserSelectedAnswer)
            .WithMany(p => p.UserStandardQuestionSelectedAnswers)
            .HasForeignKey(d => d.UserSelectedAnswerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
