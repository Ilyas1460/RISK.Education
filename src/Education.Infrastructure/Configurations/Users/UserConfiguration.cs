using Education.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("users");

        builder.HasIndex(e => e.NormalizedUserName, "uk_users_normalized_user_name").IsUnique();

        builder.HasIndex(e => e.UserName, "uk_users_user_name").IsUnique();

        builder.Property(e => e.AccessFailedCount).IsRequired();
        builder.Property(e => e.ConcurrencyStamp).IsRequired(false);
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.DeletedAt).IsRequired(false);
        builder.Property(e => e.Email).IsRequired(false);
        builder.Property(e => e.EmailConfirmed).IsRequired();
        builder.Property(e => e.Fullname).IsRequired();
        builder.Property(e => e.IsActive).IsRequired();
        builder.Property(e => e.LockoutEnabled).IsRequired();
        builder.Property(e => e.LockoutEnd).IsRequired(false);
        builder.Property(e => e.NormalizedEmail).IsRequired(false);
        builder.Property(e => e.NormalizedUserName).IsRequired(false);
        builder.Property(e => e.PasswordHash).IsRequired(false);
        builder.Property(e => e.PhoneNumber).IsRequired(false);
        builder.Property(e => e.PhoneNumberConfirmed).IsRequired();
        builder.Property(e => e.SecurityStamp).IsRequired(false);
        builder.Property(e => e.TwoFactorEnabled).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();
        builder.Property(e => e.UserName).IsRequired(false);
    }
}
