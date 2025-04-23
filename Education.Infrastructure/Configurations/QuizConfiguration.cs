using Education.Persistence.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations;

internal sealed class QuizConfiguration : SoftDeleteEntityConfiguration<Quiz>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Quiz> builder)
    {
        builder.ToTable("quizzes",
            tb => tb.HasCheckConstraint("CK_Quiz_OrderNumber_Positive", "\"order_number\" > 0"));

        builder.HasKey(q => q.Id);

        builder.Property(q => q.Title)
            .IsRequired();

        builder.Property(q => q.Description)
            .IsRequired();

        builder.Property(q => q.OrderNumber)
            .IsRequired();

        builder.HasMany(q => q.Questions)
            .WithMany(q => q.Quizzes);
    }
}
