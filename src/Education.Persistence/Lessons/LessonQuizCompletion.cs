using Education.Persistence.Abstractions;
using Education.Persistence.Users;

namespace Education.Persistence.Lessons;

public class LessonQuizCompletion : BaseEntity
{
    public int? UserId { get; set; }

    public int? LessonQuizId { get; set; }

    public virtual LessonQuiz? LessonQuiz { get; set; }

    public virtual User? User { get; set; }

    protected LessonQuizCompletion()
    {
    }
}
