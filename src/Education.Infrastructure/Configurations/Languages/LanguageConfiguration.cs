using Education.Persistence.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Languages;

public class LanguageConfiguration : SoftDeleteEntityConfiguration<Language>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("languages");

        builder.Property(e => e.Code).IsRequired();
    }
}
