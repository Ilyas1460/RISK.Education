using Education.Persistence.AspNetUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.AspNetUser;

public class AspNetUserClaimConfiguration : IEntityTypeConfiguration<AspNetUserClaim>
{
    public void Configure(EntityTypeBuilder<AspNetUserClaim> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("AspNetUserClaims");

        builder.Property(e => e.ClaimType).IsRequired(false);
        builder.Property(e => e.ClaimValue).IsRequired(false);
        builder.Property(e => e.UserId).IsRequired();
    }
}
