using Education.Persistence.Abstractions;
using Education.Persistence.Questions;

namespace Education.Persistence.Lessons;

public class LessonQuizUserQuestionAnswerLink : BaseEntity
{
    public int? UserQuestionAnswerId { get; set; }

    public int LessonQuizId { get; set; }

    public Guid LessonQuizPassageToken { get; set; }

    public virtual LessonQuiz LessonQuiz { get; set; } = null!;

    public virtual UserQuestionAnswer? UserQuestionAnswer { get; set; }
}
