using Education.Persistence.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Lessons;

public class LessonQuizConfiguration : SoftDeleteEntityConfiguration<LessonQuiz>
{
    protected override void ConfigureEntity(EntityTypeBuilder<LessonQuiz> builder)
    {
        builder.ToTable("lesson_quizes");

        builder.Property(e => e.IsActive).IsRequired();
        builder.Property(e => e.IsFree).HasDefaultValue(false).IsRequired();
        builder.Property(e => e.Title).IsRequired();
    }
}
