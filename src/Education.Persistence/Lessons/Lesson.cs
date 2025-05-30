using Education.Persistence.Abstractions;
using Education.Persistence.Contents;
using Education.Persistence.Questions;

namespace Education.Persistence.Lessons;

public class Lesson : BaseEntity
{
    public string Name { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public int? OrderInTopic { get; private set; }

    public int? TopicId { get; private set; }

    public virtual Topic? Topic { get; private set; }

    public virtual ICollection<LessonQuizLink> LessonQuizLinks { get; private set; } = new List<LessonQuizLink>();

    public virtual ICollection<LessonTheoryLink> LessonTheoryLinks { get; private set; } = new List<LessonTheoryLink>();

    public virtual ICollection<LessonVideoLink> LessonVideoLinks { get; private set; } = new List<LessonVideoLink>();

    public virtual ICollection<QuestionLessonLink> QuestionLessonLinks { get; private set; } = new List<QuestionLessonLink>();

    protected Lesson()
    {
    }
}
