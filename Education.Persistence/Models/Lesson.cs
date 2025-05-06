namespace Education.Persistence.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? TopicId { get; set; }

    public int? OrderInTopic { get; set; }

    public virtual ICollection<LessonQuizLink> LessonQuizLinks { get; set; } = new List<LessonQuizLink>();

    public virtual ICollection<LessonTheoryLink> LessonTheoryLinks { get; set; } = new List<LessonTheoryLink>();

    public virtual ICollection<LessonVideoLink> LessonVideoLinks { get; set; } = new List<LessonVideoLink>();

    public virtual ICollection<QuestionLessonLink> QuestionLessonLinks { get; set; } = new List<QuestionLessonLink>();

    public virtual Topic? Topic { get; set; }
}
