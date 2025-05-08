using Education.Persistence.Abstractions;
using Education.Persistence.Questions;

namespace Education.Persistence.Lessons;

public class LessonQuizQuestionLink : BaseEntity
{
    public int? QuestionId { get; set; }

    public int? LessonQuizId { get; set; }

    public virtual LessonQuiz? LessonQuiz { get; set; }

    public virtual Question? Question { get; set; }
}
