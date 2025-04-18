using Education.Persistence.Categories;
using Education.Persistence.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations;

internal class CourseConfiguration : SoftDeleteEntityConfiguration<Course> {
    protected override void ConfigureEntity(EntityTypeBuilder<Course> builder) {
        builder.ToTable("courses");
        
        builder.HasKey(c => c.CourseId);

        builder.Property(c => c.Title)
            .IsRequired();

        builder.Property(c => c.Description)
            .IsRequired();

        builder.HasMany(c => c.Topics)
            .WithOne(t => t.Course)
            .HasForeignKey(t => t.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.Questions)
            .WithOne(q => q.Course)
            .HasForeignKey(q => q.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}