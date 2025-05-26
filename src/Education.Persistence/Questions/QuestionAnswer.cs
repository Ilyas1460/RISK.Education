using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class QuestionAnswer : BaseEntity
{
    public string? Text { get; set; }

    public bool IsCorrect { get; set; }

    public int? QuestionId { get; set; }

    public int Type { get; set; }

    public virtual ICollection<PublicStandardQuestionSelectedAnswer> PublicStandardQuestionSelectedAnswers { get; set; } = new List<PublicStandardQuestionSelectedAnswer>();

    public virtual Question? Question { get; set; }

    public virtual ICollection<QuestionAnswerImage> QuestionAnswerImages { get; set; } = new List<QuestionAnswerImage>();

    public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; set; } = new List<UserQuestionAnswer>();

    public virtual ICollection<UserStandardQuestionSelectedAnswer> UserStandardQuestionSelectedAnswers { get; set; } = new List<UserStandardQuestionSelectedAnswer>();
}
