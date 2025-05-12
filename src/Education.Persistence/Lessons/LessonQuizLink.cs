using Education.Persistence.Abstractions;

namespace Education.Persistence.Lessons;

public class LessonQuizLink : BaseEntity
{
    public int? LessonId { get; set; }

    public int? LessonQuizId { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual LessonQuiz? LessonQuiz { get; set; }
}
