namespace Education.Persistence.Models;

public partial class UserQuestionAnswer
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? QuestionId { get; set; }

    public bool AnsweredCorrect { get; set; }

    public int? QuestionAnswerEntityId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<LessonQuizUserQuestionAnswerLink> LessonQuizUserQuestionAnswerLinks { get; set; } = new List<LessonQuizUserQuestionAnswerLink>();

    public virtual Question? Question { get; set; }

    public virtual QuestionAnswer? QuestionAnswerEntity { get; set; }

    public virtual ICollection<TestExamHistoryUserQuestionAnswerLink> TestExamHistoryUserQuestionAnswerLinks { get; set; } = new List<TestExamHistoryUserQuestionAnswerLink>();

    public virtual User? User { get; set; }

    public virtual ICollection<UserOpenQuestionSelectedAnswer> UserOpenQuestionSelectedAnswers { get; set; } = new List<UserOpenQuestionSelectedAnswer>();

    public virtual ICollection<UserStandardQuestionSelectedAnswer> UserStandardQuestionSelectedAnswers { get; set; } = new List<UserStandardQuestionSelectedAnswer>();
}
