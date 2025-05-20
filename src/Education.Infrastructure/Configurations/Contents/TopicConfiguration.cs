using Education.Persistence.Contents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Contents;

public class TopicConfiguration : SoftDeleteEntityConfiguration<Topic>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("topics");

        builder.Property(e => e.CourseId).IsRequired(false);
        builder.Property(e => e.Description).IsRequired(false);
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.OrderInCourse).IsRequired(false);

        builder.HasOne(d => d.Course)
            .WithMany(p => p.Topics)
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
