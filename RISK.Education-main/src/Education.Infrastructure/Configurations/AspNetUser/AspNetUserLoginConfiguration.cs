using Education.Persistence.AspNetUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.AspNetUser;

public class AspNetUserLoginConfiguration : IEntityTypeConfiguration<AspNetUserLogin>
{
    public void Configure(EntityTypeBuilder<AspNetUserLogin> builder)
    {
        builder.HasKey(e => new { e.LoginProvider, e.ProviderKey })
            .HasName("pk_asp_net_user_logins");

        builder.ToTable("AspNetUserLogins");

        builder.Property(e => e.ProviderDisplayName).IsRequired(false);
        builder.Property(e => e.UserId).IsRequired();
    }
}
