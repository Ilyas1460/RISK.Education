using Education.Persistence.Abstractions;
using Education.Persistence.Questions;

namespace Education.Persistence.Lessons;

public class LessonQuizQuestionLink : BaseEntity
{
    public int? QuestionId { get; private set; }

    public int? LessonQuizId { get; private set; }

    public virtual LessonQuiz? LessonQuiz { get; private set; }

    public virtual Question? Question { get; private set; }
}
