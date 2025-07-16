using Education.Persistence.Abstractions;
using Education.Persistence.Users;

namespace Education.Persistence.Courses;

public class UserCourse : BaseEntity
{
    public int? CourseId { get; set; }

    public int? UserId { get; set; }

    public int CourseAccessType { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime ExpireTime { get; set; }

    public virtual Course? Course { get; set; }

    public virtual User? User { get; set; }
}
