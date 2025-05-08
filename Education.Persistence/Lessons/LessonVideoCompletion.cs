using Education.Persistence.Abstractions;
using Education.Persistence.Users;

namespace Education.Persistence.Lessons;

public class LessonVideoCompletion : BaseEntity
{
    public int? UserId { get; set; }

    public int? LessonVideoId { get; set; }

    public virtual LessonVideo? LessonVideo { get; set; }

    public virtual User? User { get; set; }
}
