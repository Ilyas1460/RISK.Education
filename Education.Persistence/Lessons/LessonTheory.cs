using Education.Persistence.Contents;

namespace Education.Persistence.Lessons;

public class LessonTheory
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool IsFree { get; set; }

    public virtual ICollection<LessonTheoryCompletion> LessonTheoryCompletions { get; set; } = new List<LessonTheoryCompletion>();

    public virtual ICollection<LessonTheoryLink> LessonTheoryLinks { get; set; } = new List<LessonTheoryLink>();

    public virtual ICollection<TopicContent> TopicContents { get; set; } = new List<TopicContent>();
}
