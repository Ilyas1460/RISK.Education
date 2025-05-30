using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class PublicStandardQuestionSelectedAnswer : BaseEntity
{
    public int? PublicQuestionAnswerId { get; private set; }

    public int SelectedAnswerId { get; private set; }

    public int? QuestionAnswerId { get; private set; }

    public virtual PublicQuestionAnswer? PublicQuestionAnswer { get; private set; }

    public virtual QuestionAnswer? QuestionAnswer { get; private set; }
}
