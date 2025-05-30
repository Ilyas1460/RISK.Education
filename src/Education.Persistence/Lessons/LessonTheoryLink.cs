using Education.Persistence.Abstractions;

namespace Education.Persistence.Lessons;

public class LessonTheoryLink : BaseEntity
{
    public int? LessonId { get; private set; }

    public int? LessonTheoryId { get; private set; }

    public virtual Lesson? Lesson { get; private set; }

    public virtual LessonTheory? LessonTheory { get; private set; }
}
