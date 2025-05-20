using Education.Persistence.Abstractions;
using Education.Persistence.Contents;

namespace Education.Persistence.Lessons;

public class LessonTheory : BaseEntity
{
    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsFree { get; set; }

    public virtual ICollection<LessonTheoryCompletion> LessonTheoryCompletions { get; set; } = new List<LessonTheoryCompletion>();

    public virtual ICollection<LessonTheoryLink> LessonTheoryLinks { get; set; } = new List<LessonTheoryLink>();

    public virtual ICollection<TopicContent> TopicContents { get; set; } = new List<TopicContent>();
}
