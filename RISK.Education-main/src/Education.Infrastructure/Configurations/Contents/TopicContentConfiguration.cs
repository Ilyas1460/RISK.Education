using Education.Persistence.Contents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Contents;

public class TopicContentConfiguration : SoftDeleteEntityConfiguration<TopicContent>
{
    protected override void ConfigureEntity(EntityTypeBuilder<TopicContent> builder)
    {
        builder.ToTable("topic_contents");

        builder.Property(e => e.LessonQuizId).IsRequired(false);
        builder.Property(e => e.LessonTheoryId).IsRequired(false);
        builder.Property(e => e.LessonVideoId).IsRequired(false);
        builder.Property(e => e.Order).IsRequired();
        builder.Property(e => e.TopicId).IsRequired();
        builder.Property(e => e.Type).IsRequired();

        builder.HasOne(d => d.LessonQuiz)
            .WithMany(p => p.TopicContents)
            .HasForeignKey(d => d.LessonQuizId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.LessonTheory)
            .WithMany(p => p.TopicContents)
            .HasForeignKey(d => d.LessonTheoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.LessonVideo)
            .WithMany(p => p.TopicContents)
            .HasForeignKey(d => d.LessonVideoId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.Topic)
            .WithMany(p => p.TopicContents)
            .HasForeignKey(d => d.TopicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
