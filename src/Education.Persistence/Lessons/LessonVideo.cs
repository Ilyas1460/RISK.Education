using Education.Persistence.Abstractions;
using Education.Persistence.Contents;

namespace Education.Persistence.Lessons;

public class LessonVideo : BaseEntity
{
    public string Title { get; private set; } = null!;

    public string Url { get; private set; } = null!;

    public bool IsActive { get; private set; }

    public bool IsFree { get; private set; }

    public virtual ICollection<LessonVideoCompletion> LessonVideoCompletions { get; private set; } = new List<LessonVideoCompletion>();

    public virtual ICollection<LessonVideoLink> LessonVideoLinks { get; private set; } = new List<LessonVideoLink>();

    public virtual ICollection<TopicContent> TopicContents { get; private set; } = new List<TopicContent>();
}
