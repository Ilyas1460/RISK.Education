namespace Education.Persistence.Models;

public partial class LessonVideo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Url { get; set; } = null!;

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool IsFree { get; set; }

    public virtual ICollection<LessonVideoCompletion> LessonVideoCompletions { get; set; } = new List<LessonVideoCompletion>();

    public virtual ICollection<LessonVideoLink> LessonVideoLinks { get; set; } = new List<LessonVideoLink>();

    public virtual ICollection<TopicContent> TopicContents { get; set; } = new List<TopicContent>();
}
