using Education.Persistence.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations;

internal sealed class QuestionConfiguration : SoftDeleteEntityConfiguration<Question>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("questions");

        builder.HasKey(q => q.Id);

        builder.Property(q => q.Content)
            .IsRequired();

        builder.Property(q => q.Type)
            .IsRequired()
            .HasColumnType("smallint");

        builder.HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
