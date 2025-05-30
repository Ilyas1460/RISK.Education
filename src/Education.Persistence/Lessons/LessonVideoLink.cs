using Education.Persistence.Abstractions;

namespace Education.Persistence.Lessons;

public class LessonVideoLink : BaseEntity
{
    public int? LessonId { get; private set; }

    public int? LessonVideoId { get; private set; }

    public virtual Lesson? Lesson { get; private set; }

    public virtual LessonVideo? LessonVideo { get; private set; }
}
