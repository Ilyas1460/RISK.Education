using Education.Persistence.Abstractions;
using Education.Persistence.Lessons;

namespace Education.Persistence.Contents;

public class TopicContent : BaseEntity
{
    public int TopicId { get; private set; }

    public int? LessonTheoryId { get; private set; }

    public int? LessonVideoId { get; private set; }

    public int Type { get; private set; }

    public int Order { get; private set; }

    public int? LessonQuizId { get; private set; }

    public virtual LessonQuiz? LessonQuiz { get; private set; }

    public virtual LessonTheory? LessonTheory { get; private set; }

    public virtual LessonVideo? LessonVideo { get; private set; }

    public virtual Topic Topic { get; private set; }
}
