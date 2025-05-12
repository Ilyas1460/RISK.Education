using Education.Persistence.Abstractions;

namespace Education.Persistence.Lessons;

public class LessonTheoryLink : BaseEntity
{
    public int? LessonId { get; set; }

    public int? LessonTheoryId { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual LessonTheory? LessonTheory { get; set; }
}
