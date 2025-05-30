using Education.Persistence.Abstractions;
using Education.Persistence.Users;

namespace Education.Persistence.Lessons;

public class LessonVideoCompletion : BaseEntity
{
    public int? UserId { get; private set; }

    public int? LessonVideoId { get; private set; }

    public virtual LessonVideo? LessonVideo { get; private set; }

    public virtual User? User { get; private set; }
}
