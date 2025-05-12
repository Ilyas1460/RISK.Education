using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class PublicQuestionAnswerConfiguration : SoftDeleteEntityConfiguration<PublicQuestionAnswer>
{
    protected override void ConfigureEntity(EntityTypeBuilder<PublicQuestionAnswer> builder)
    {
        builder.ToTable("public_question_answers");

        builder.Property(e => e.AnsweredCorrect).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.PublicId).IsRequired(false);
        builder.Property(e => e.QuestionId).IsRequired(false);

        builder.HasOne(d => d.Question)
            .WithMany(p => p.PublicQuestionAnswers)
            .HasForeignKey(d => d.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
