using Education.Persistence.Topics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations;

internal class TopicConfiguration : SoftDeleteEntityConfiguration<Topic>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("topics",
            tb => tb.HasCheckConstraint("CK_Topic_OrderNumber_Positive", "\"order_number\" > 0"));

        builder.HasKey(t => t.TopicId);

        builder.Property(t => t.Title)
            .IsRequired();

        builder.Property(t => t.Description)
            .IsRequired();

        builder.Property(t => t.OrderNumber)
            .IsRequired();

        builder.HasMany(t => t.Theories)
            .WithOne(t => t.Topic)
            .HasForeignKey(t => t.TopicId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Videos)
            .WithOne(v => v.Topic)
            .HasForeignKey(v => v.TopicId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Quizzes)
            .WithOne(q => q.Topic)
            .HasForeignKey(q => q.TopicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
