using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class QuestionConfiguration : SoftDeleteEntityConfiguration<Question>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("questions");

        builder.Property(e => e.AnswerExplanation).IsRequired();
        builder.Property(e => e.AudioUrl).IsRequired(false);
        builder.Property(e => e.IsActive).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.IsFree).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.Level).HasDefaultValue(0).IsRequired();
        builder.Property(e => e.Question1).IsRequired();
        builder.Property(e => e.QuestionType).HasDefaultValue(0).IsRequired();
    }
}
