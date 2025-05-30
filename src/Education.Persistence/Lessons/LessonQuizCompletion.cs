using Education.Persistence.Abstractions;
using Education.Persistence.Users;

namespace Education.Persistence.Lessons;

public class LessonQuizCompletion : BaseEntity
{
    public int? UserId { get; private set; }

    public int? LessonQuizId { get; private set; }

    public virtual LessonQuiz? LessonQuiz { get; private set; }

    public virtual User? User { get; private set; }

    protected LessonQuizCompletion()
    {
    }
}
