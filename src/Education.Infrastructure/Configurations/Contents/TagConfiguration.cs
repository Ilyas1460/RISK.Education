using Education.Persistence.Contents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Contents;

public class TagConfiguration : SoftDeleteEntityConfiguration<Tag>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("tags");

        builder.Property(e => e.Name).IsRequired();
    }
}
