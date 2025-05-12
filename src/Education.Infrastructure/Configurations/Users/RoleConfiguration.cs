using Education.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Users;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("roles");

        builder.Property(e => e.ConcurrencyStamp).IsRequired(false);
        builder.Property(e => e.Name).IsRequired(false);
        builder.Property(e => e.NormalizedName).IsRequired(false);
    }
}
