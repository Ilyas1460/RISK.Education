namespace Education.Persistence.Lessons;

public class LessonQuizLink
{
    public int Id { get; set; }

    public int? LessonId { get; set; }

    public int? LessonQuizId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual LessonQuiz? LessonQuiz { get; set; }
}
