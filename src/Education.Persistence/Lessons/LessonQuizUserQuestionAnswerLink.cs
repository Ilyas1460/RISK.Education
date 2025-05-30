using Education.Persistence.Abstractions;
using Education.Persistence.Questions;

namespace Education.Persistence.Lessons;

public class LessonQuizUserQuestionAnswerLink : BaseEntity
{
    public int? UserQuestionAnswerId { get; private set; }

    public int LessonQuizId { get; private set; }

    public Guid LessonQuizPassageToken { get; private set; }

    public virtual LessonQuiz LessonQuiz { get; private set; } = null!;

    public virtual UserQuestionAnswer? UserQuestionAnswer { get; private set; }
}
