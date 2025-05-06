namespace Education.Persistence.Models;

public partial class QuestionAnswer
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public bool IsCorrect { get; set; }

    public int? QuestionId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int Type { get; set; }

    public virtual ICollection<PublicStandardQuestionSelectedAnswer> PublicStandardQuestionSelectedAnswers { get; set; } = new List<PublicStandardQuestionSelectedAnswer>();

    public virtual Question? Question { get; set; }

    public virtual ICollection<QuestionAnswerImage> QuestionAnswerImages { get; set; } = new List<QuestionAnswerImage>();

    public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; set; } = new List<UserQuestionAnswer>();

    public virtual ICollection<UserStandardQuestionSelectedAnswer> UserStandardQuestionSelectedAnswers { get; set; } = new List<UserStandardQuestionSelectedAnswer>();
}
