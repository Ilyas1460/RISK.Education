using Education.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Users;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("role_claims");

        builder.Property(e => e.ClaimType).IsRequired(false);
        builder.Property(e => e.ClaimValue).IsRequired(false);
        builder.Property(e => e.RoleId).IsRequired();
    }
}
