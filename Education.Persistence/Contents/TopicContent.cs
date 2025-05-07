using Education.Persistence.Lessons;

namespace Education.Persistence.Contents;

public class TopicContent
{
    public int Id { get; set; }

    public int TopicId { get; set; }

    public int? LessonTheoryId { get; set; }

    public int? LessonVideoId { get; set; }

    public int Type { get; set; }

    public int Order { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? LessonQuizId { get; set; }

    public virtual LessonQuiz? LessonQuiz { get; set; }

    public virtual LessonTheory? LessonTheory { get; set; }

    public virtual LessonVideo? LessonVideo { get; set; }

    public virtual Topic Topic { get; set; } = null!;
}
