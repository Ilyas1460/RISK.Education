using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class PublicQuestionAnswer : BaseEntity
{
    public string? PublicId { get; private set; }

    public int? QuestionId { get; private set; }

    public bool AnsweredCorrect { get; private set; }

    public virtual ICollection<PublicOpenQuestionSelectedAnswer> PublicOpenQuestionSelectedAnswers { get; private set; } = new List<PublicOpenQuestionSelectedAnswer>();

    public virtual ICollection<PublicStandardQuestionSelectedAnswer> PublicStandardQuestionSelectedAnswers { get; private set; } = new List<PublicStandardQuestionSelectedAnswer>();

    public virtual Question? Question { get; private set; }
}
