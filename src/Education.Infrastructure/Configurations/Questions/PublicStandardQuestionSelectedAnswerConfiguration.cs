using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class
    PublicStandardQuestionSelectedAnswerConfiguration : SoftDeleteEntityConfiguration<
    PublicStandardQuestionSelectedAnswer>
{
    protected override void ConfigureEntity(EntityTypeBuilder<PublicStandardQuestionSelectedAnswer> builder)
    {
        builder.ToTable("public_standard_question_selected_answers");

        builder.Property(e => e.PublicQuestionAnswerId).IsRequired(false);
        builder.Property(e => e.QuestionAnswerId).IsRequired(false);
        builder.Property(e => e.SelectedAnswerId).IsRequired();

        builder.HasOne(d => d.PublicQuestionAnswer)
            .WithMany(p => p.PublicStandardQuestionSelectedAnswers)
            .HasForeignKey(d => d.PublicQuestionAnswerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.QuestionAnswer)
            .WithMany(p => p.PublicStandardQuestionSelectedAnswers)
            .HasForeignKey(d => d.QuestionAnswerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
