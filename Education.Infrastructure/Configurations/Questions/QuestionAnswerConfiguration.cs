using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class QuestionAnswerConfiguration : SoftDeleteEntityConfiguration<QuestionAnswer>
{
    protected override void ConfigureEntity(EntityTypeBuilder<QuestionAnswer> builder)
    {
        builder.ToTable("question_answers");

        builder.Property(e => e.IsCorrect).IsRequired();
        builder.Property(e => e.QuestionId).IsRequired(false);
        builder.Property(e => e.Text).IsRequired(false);
        builder.Property(e => e.Type).HasDefaultValue(0).IsRequired();

        builder.HasOne(d => d.Question)
            .WithMany(p => p.QuestionAnswers)
            .HasForeignKey(d => d.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
