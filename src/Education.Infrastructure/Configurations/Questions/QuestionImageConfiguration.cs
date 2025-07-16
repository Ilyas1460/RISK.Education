using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Questions;

public class QuestionImageConfiguration : SoftDeleteEntityConfiguration<QuestionImage>
{
    protected override void ConfigureEntity(EntityTypeBuilder<QuestionImage> builder)
    {
        builder.ToTable("question_images");

        builder.Property(e => e.ImageAlt).IsRequired(false);
        builder.Property(e => e.ImageUrl).IsRequired();
        builder.Property(e => e.Order).IsRequired();
        builder.Property(e => e.QuestionId).IsRequired();

        builder.HasOne(d => d.Question)
            .WithMany(p => p.QuestionImages)
            .HasForeignKey(d => d.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
