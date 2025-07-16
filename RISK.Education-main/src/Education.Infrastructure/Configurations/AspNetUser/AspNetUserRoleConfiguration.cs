using Education.Persistence.AspNetUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.AspNetUser;

public class AspNetUserRoleConfiguration : IEntityTypeConfiguration<AspNetUserRole>
{
    public void Configure(EntityTypeBuilder<AspNetUserRole> builder)
    {
        builder.HasKey(e => new { e.UserId, e.RoleId })
            .HasName("pk_asp_net_user_roles");

        builder.ToTable("AspNetUserRoles");
    }
}
