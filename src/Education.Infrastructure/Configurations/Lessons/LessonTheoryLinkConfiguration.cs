using Education.Persistence.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Lessons;

public class LessonTheoryLinkConfiguration : SoftDeleteEntityConfiguration<LessonTheoryLink>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LessonTheoryLink> builder)
    {
        builder.ToTable("lesson_theory_links");

        builder.Property(e => e.LessonId).IsRequired(false);
        builder.Property(e => e.LessonTheoryId).IsRequired(false);

        builder.HasOne(d => d.Lesson)
            .WithMany(p => p.LessonTheoryLinks)
            .HasForeignKey(d => d.LessonId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.LessonTheory)
            .WithMany(p => p.LessonTheoryLinks)
            .HasForeignKey(d => d.LessonTheoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
