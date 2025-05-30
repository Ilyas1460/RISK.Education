using Education.Persistence.Abstractions;

namespace Education.Persistence.Users;

public class AdminUser : BaseEntity
{
    public string Username { get; private set; } = null!;

    public string Password { get; private set; } = null!;

    public virtual ICollection<AdminUserRoleLink> AdminUserRoleLinks { get; private set; } = new List<AdminUserRoleLink>();
}
