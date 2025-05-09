using Education.Persistence.Contents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Contents;

public class ContactUsRequestConfiguration : SoftDeleteEntityConfiguration<ContactUsRequest>
{
    protected override void ConfigureEntity(EntityTypeBuilder<ContactUsRequest> builder)
    {
        builder.ToTable("contact_us_requests");

        builder.Property(e => e.FullName).IsRequired(false);
        builder.Property(e => e.Message).IsRequired(false);
        builder.Property(e => e.PhoneNumber).IsRequired(false);
    }
}
