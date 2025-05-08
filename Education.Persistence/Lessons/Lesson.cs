using Education.Persistence.Abstractions;
using Education.Persistence.Contents;
using Education.Persistence.Questions;

namespace Education.Persistence.Lessons;

public class Lesson : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? OrderInTopic { get; set; }

    public int? TopicId { get; set; }

    public virtual Topic? Topic { get; set; }

    public virtual ICollection<LessonQuizLink> LessonQuizLinks { get; set; } = new List<LessonQuizLink>();

    public virtual ICollection<LessonTheoryLink> LessonTheoryLinks { get; set; } = new List<LessonTheoryLink>();

    public virtual ICollection<LessonVideoLink> LessonVideoLinks { get; set; } = new List<LessonVideoLink>();

    public virtual ICollection<QuestionLessonLink> QuestionLessonLinks { get; set; } = new List<QuestionLessonLink>();

    protected Lesson()
    {
    }
}
