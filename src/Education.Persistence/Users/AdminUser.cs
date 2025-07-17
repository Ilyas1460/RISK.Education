using Education.Persistence.Abstractions;

namespace Education.Persistence.Users;

public class AdminUser : BaseEntity
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<AdminUserRoleLink> AdminUserRoleLinks { get; set; } = new List<AdminUserRoleLink>();
}
