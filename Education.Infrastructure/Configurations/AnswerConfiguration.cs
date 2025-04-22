using Education.Persistence.Answers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations;

internal class AnswerConfiguration : SoftDeleteEntityConfiguration<Answer>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("answers");

        builder.Property(a => a.Content)
            .IsRequired();

        builder.Property(a => a.IsCorrect)
            .IsRequired();
    }
}
