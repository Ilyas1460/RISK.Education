using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class UserOpenQuestionSelectedAnswerConfiguration : SoftDeleteEntityConfiguration<UserOpenQuestionSelectedAnswer>
{
    protected override void ConfigureEntity(EntityTypeBuilder<UserOpenQuestionSelectedAnswer> builder)
    {
        builder.ToTable("user_open_question_selected_answers");

        builder.Property(e => e.Answer).IsRequired();
        builder.Property(e => e.UserQuestionAnswerId).IsRequired(false);

        builder.HasOne(d => d.UserQuestionAnswer)
            .WithMany(p => p.UserOpenQuestionSelectedAnswers)
            .HasForeignKey(d => d.UserQuestionAnswerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
