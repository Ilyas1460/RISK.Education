using Education.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Users;

public class AdminUserConfiguration : SoftDeleteEntityConfiguration<AdminUser>
{
    protected override void ConfigureEntity(EntityTypeBuilder<AdminUser> builder)
    {
        builder.ToTable("admin_users");

        builder.Property(e => e.Password).IsRequired();
        builder.Property(e => e.Username).IsRequired();
    }
}
