using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class PublicQuestionAnswer : BaseEntity
{
    public string? PublicId { get; set; }

    public int? QuestionId { get; set; }

    public bool AnsweredCorrect { get; set; }

    public virtual ICollection<PublicOpenQuestionSelectedAnswer> PublicOpenQuestionSelectedAnswers { get; set; } = new List<PublicOpenQuestionSelectedAnswer>();

    public virtual ICollection<PublicStandardQuestionSelectedAnswer> PublicStandardQuestionSelectedAnswers { get; set; } = new List<PublicStandardQuestionSelectedAnswer>();

    public virtual Question? Question { get; set; }
}
