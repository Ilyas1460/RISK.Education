using Education.Persistence.Abstractions;
using Education.Persistence.Courses;

namespace Education.Persistence.Users;

public class AdminUserRoleLink : BaseEntity
{
    public int AdminUserId { get; private set; }

    public int? CourseId { get; private set; }

    public int AdminRole { get; private set; }

    public virtual AdminUser AdminUser { get; private set; } = null!;

    public virtual Course? Course { get; private set; }
}
