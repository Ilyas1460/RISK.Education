using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class RelatedQuestionLinkConfiguration : SoftDeleteEntityConfiguration<RelatedQuestionLink>
{
    protected override void ConfigureEntity(EntityTypeBuilder<RelatedQuestionLink> builder)
    {
        builder.ToTable("related_question_links");

        builder.Property(e => e.Order).IsRequired();
        builder.Property(e => e.QuestionId).IsRequired(false);
        builder.Property(e => e.RelatedQuestionId).IsRequired(false);

        builder.HasOne(d => d.Question)
            .WithMany(p => p.RelatedQuestionLinks)
            .HasForeignKey(d => d.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.RelatedQuestion)
            .WithMany(p => p.RelatedQuestionLinks)
            .HasForeignKey(d => d.RelatedQuestionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
