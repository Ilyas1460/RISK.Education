using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class RelatedQuestionConfiguration : SoftDeleteEntityConfiguration<RelatedQuestion>
{
    protected override void ConfigureEntity(EntityTypeBuilder<RelatedQuestion> builder)
    {
        builder.ToTable("related_questions");

        builder.Property(e => e.AudioUrl).IsRequired(false);
        builder.Property(e => e.Question).IsRequired();
        builder.Property(e => e.QuestionType).IsRequired();
    }
}
