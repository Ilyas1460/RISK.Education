using Education.Persistence.Abstractions;

namespace Education.Persistence.Lessons;

public class LessonQuizLink : BaseEntity
{
    public int? LessonId { get; private set; }

    public int? LessonQuizId { get; private set; }

    public virtual Lesson? Lesson { get; private set; }

    public virtual LessonQuiz? LessonQuiz { get; private set; }
}
