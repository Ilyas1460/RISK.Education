using Education.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Users;

public class AdminUserRoleLinkConfiguration : SoftDeleteEntityConfiguration<AdminUserRoleLink>
{
    protected override void ConfigureEntity(EntityTypeBuilder<AdminUserRoleLink> builder)
    {
        builder.ToTable("admin_user_role_links");

        builder.Property(e => e.AdminRole).IsRequired();
        builder.Property(e => e.AdminUserId).IsRequired();
        builder.Property(e => e.CourseId).IsRequired(false);

        builder.HasOne(d => d.AdminUser)
            .WithMany(p => p.AdminUserRoleLinks)
            .HasForeignKey(d => d.AdminUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Course)
            .WithMany(p => p.AdminUserRoleLinks)
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

