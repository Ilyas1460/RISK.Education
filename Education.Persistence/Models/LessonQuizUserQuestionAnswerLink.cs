namespace Education.Persistence.Models;

public partial class LessonQuizUserQuestionAnswerLink
{
    public int Id { get; set; }

    public int? UserQuestionAnswerId { get; set; }

    public int LessonQuizId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid LessonQuizPassageToken { get; set; }

    public virtual LessonQuize LessonQuiz { get; set; } = null!;

    public virtual UserQuestionAnswer? UserQuestionAnswer { get; set; }
}
