using Education.Persistence.Abstractions;
using Education.Persistence.Contents;

namespace Education.Persistence.Lessons;

public class LessonTheory : BaseEntity
{
    public string Title { get; private set; } = null!;

    public string Content { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public bool IsFree { get; private set; }

    public virtual ICollection<LessonTheoryCompletion> LessonTheoryCompletions { get; private set; } = new List<LessonTheoryCompletion>();

    public virtual ICollection<LessonTheoryLink> LessonTheoryLinks { get; private set; } = new List<LessonTheoryLink>();

    public virtual ICollection<TopicContent> TopicContents { get; private set; } = new List<TopicContent>();
}
