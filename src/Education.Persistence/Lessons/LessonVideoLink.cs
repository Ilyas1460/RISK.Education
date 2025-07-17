using Education.Persistence.Abstractions;

namespace Education.Persistence.Lessons;

public class LessonVideoLink : BaseEntity
{
    public int? LessonId { get; set; }

    public int? LessonVideoId { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual LessonVideo? LessonVideo { get; set; }
}
