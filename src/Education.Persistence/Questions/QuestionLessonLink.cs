using Education.Persistence.Abstractions;
using Education.Persistence.Lessons;

namespace Education.Persistence.Questions;

public class QuestionLessonLink : BaseEntity
{
    public int? LessonId { get; private set; }

    public int? QuestionId { get; private set; }

    public virtual Lesson? Lesson { get; private set; }

    public virtual Question? Question { get; private set; }
}
