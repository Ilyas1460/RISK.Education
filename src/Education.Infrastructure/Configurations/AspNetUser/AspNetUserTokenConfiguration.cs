using Education.Persistence.AspNetUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.AspNetUser;

public class AspNetUserTokenConfiguration : IEntityTypeConfiguration<AspNetUserToken>
{
    public void Configure(EntityTypeBuilder<AspNetUserToken> builder)
    {
        builder.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
            .HasName("pk_asp_net_user_tokens");

        builder.ToTable("AspNetUserTokens");

        builder.Property(e => e.Value).IsRequired(false);
    }
}
