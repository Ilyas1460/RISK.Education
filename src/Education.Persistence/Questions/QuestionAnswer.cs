using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class QuestionAnswer : BaseEntity
{
    public string? Text { get; private set; }

    public bool IsCorrect { get; private set; }

    public int? QuestionId { get; private set; }

    public int Type { get; private set; }

    public virtual ICollection<PublicStandardQuestionSelectedAnswer> PublicStandardQuestionSelectedAnswers { get; private set; } = new List<PublicStandardQuestionSelectedAnswer>();

    public virtual Question? Question { get; private set; }

    public virtual ICollection<QuestionAnswerImage> QuestionAnswerImages { get; private set; } = new List<QuestionAnswerImage>();

    public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; private set; } = new List<UserQuestionAnswer>();

    public virtual ICollection<UserStandardQuestionSelectedAnswer> UserStandardQuestionSelectedAnswers { get; private set; } = new List<UserStandardQuestionSelectedAnswer>();
}
