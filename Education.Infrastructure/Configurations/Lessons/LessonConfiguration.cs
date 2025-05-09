using Education.Persistence.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Lessons;

public class LessonConfiguration : SoftDeleteEntityConfiguration<Lesson>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("lessons");

        builder.Property(e => e.Description).IsRequired();
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.OrderInTopic).IsRequired(false);
        builder.Property(e => e.TopicId).IsRequired(false);

        builder.HasOne(e => e.Topic)
            .WithMany(t => t.Lessons)
            .HasForeignKey(e => e.TopicId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
