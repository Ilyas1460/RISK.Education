using Education.Persistence.Abstractions;
using Education.Persistence.Users;

namespace Education.Persistence.Lessons;

public class LessonTheoryCompletion : BaseEntity
{
    public int? UserId { get; set; }

    public int? LessonTheoryId { get; set; }

    public virtual LessonTheory? LessonTheory { get; set; }

    public virtual User? User { get; set; }
}
