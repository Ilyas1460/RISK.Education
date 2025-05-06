namespace Education.Persistence.Models;

public partial class LessonQuize
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool IsFree { get; set; }

    public virtual ICollection<LessonQuizCompletion> LessonQuizCompletions { get; set; } = new List<LessonQuizCompletion>();

    public virtual ICollection<LessonQuizLink> LessonQuizLinks { get; set; } = new List<LessonQuizLink>();

    public virtual ICollection<LessonQuizQuestionLink> LessonQuizQuestionLinks { get; set; } = new List<LessonQuizQuestionLink>();

    public virtual ICollection<LessonQuizUserQuestionAnswerLink> LessonQuizUserQuestionAnswerLinks { get; set; } = new List<LessonQuizUserQuestionAnswerLink>();

    public virtual ICollection<TopicContent> TopicContents { get; set; } = new List<TopicContent>();
}
