using Education.Persistence.Abstractions;
using Education.Persistence.Contents;

namespace Education.Persistence.Lessons;

public class LessonVideo : BaseEntity
{
    public string Title { get; set; } = null!;

    public string Url { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsFree { get; set; }

    public virtual ICollection<LessonVideoCompletion> LessonVideoCompletions { get; set; } = new List<LessonVideoCompletion>();

    public virtual ICollection<LessonVideoLink> LessonVideoLinks { get; set; } = new List<LessonVideoLink>();

    public virtual ICollection<TopicContent> TopicContents { get; set; } = new List<TopicContent>();
}
