using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class QuestionReviewConfiguration : SoftDeleteEntityConfiguration<QuestionReview>
{
    protected override void ConfigureEntity(EntityTypeBuilder<QuestionReview> builder)
    {
        builder.ToTable("question_reviews");

        builder.Property(e => e.Comment).IsRequired(false);
        builder.Property(e => e.QuestionBugStatus).HasDefaultValue(0).IsRequired();
        builder.Property(e => e.QuestionId).IsRequired(false);
        builder.Property(e => e.QuestionReviewStatus).HasDefaultValue(1).IsRequired();

        builder.HasOne(d => d.Question)
            .WithMany(p => p.QuestionReviews)
            .HasForeignKey(d => d.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
