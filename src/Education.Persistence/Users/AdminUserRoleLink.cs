using Education.Persistence.Abstractions;
using Education.Persistence.Courses;

namespace Education.Persistence.Users;

public class AdminUserRoleLink : BaseEntity
{
    public int AdminUserId { get; set; }

    public int? CourseId { get; set; }

    public int AdminRole { get; set; }

    public virtual AdminUser AdminUser { get; set; } = null!;

    public virtual Course? Course { get; set; }
}
