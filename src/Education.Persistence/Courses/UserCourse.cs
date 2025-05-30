using Education.Persistence.Abstractions;
using Education.Persistence.Users;

namespace Education.Persistence.Courses;

public class UserCourse : BaseEntity
{
    public int? CourseId { get; private set; }

    public int? UserId { get; private set; }

    public int CourseAccessType { get; private set; }

    public DateTime StartTime { get; private set; }

    public DateTime ExpireTime { get; private set; }

    public virtual Course? Course { get; private set; }

    public virtual User? User { get; private set; }
}
