using Education.Persistence.Abstractions;
using Education.Persistence.Lessons;

namespace Education.Persistence.Questions;

public class QuestionLessonLink : BaseEntity
{
    public int? LessonId { get; set; }

    public int? QuestionId { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual Question? Question { get; set; }
}
