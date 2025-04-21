using Education.Persistence.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations;

internal class LanguageConfiguration : SoftDeleteEntityConfiguration<Language> {
    protected override void ConfigureEntity(EntityTypeBuilder<Language> builder) {
        builder.ToTable("languages");
        
        builder.HasKey(l => l.LanguageId);

        builder.Property(l => l.Name)
            .IsRequired();

        builder.Property(l => l.Code)
            .IsRequired()
            .HasMaxLength(5);

        builder.HasIndex(l => l.Name)
            .IsUnique();
        
        builder.HasIndex(l => l.Code)
            .IsUnique();
        
        builder.HasMany(l => l.Courses)
            .WithOne(c => c.Language)
            .HasForeignKey(c => c.LanguageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}