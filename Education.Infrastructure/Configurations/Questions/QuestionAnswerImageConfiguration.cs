using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class QuestionAnswerImageConfiguration : SoftDeleteEntityConfiguration<QuestionAnswerImage>
{
    protected override void ConfigureEntity(EntityTypeBuilder<QuestionAnswerImage> builder)
    {
        builder.ToTable("question_answer_images");

        builder.Property(e => e.ImageAlt).IsRequired(false);
        builder.Property(e => e.ImageUrl).IsRequired();
        builder.Property(e => e.Order).IsRequired();
        builder.Property(e => e.QuestionAnswerId).IsRequired();

        builder.HasOne(d => d.QuestionAnswer)
            .WithMany(p => p.QuestionAnswerImages)
            .HasForeignKey(d => d.QuestionAnswerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
