using Education.Persistence.Abstractions;
using Education.Persistence.Users;

namespace Education.Persistence.Lessons;

public class LessonTheoryCompletion : BaseEntity
{
    public int? UserId { get; private set; }

    public int? LessonTheoryId { get; private set; }

    public virtual LessonTheory? LessonTheory { get; private set; }

    public virtual User? User { get; private set; }
}
