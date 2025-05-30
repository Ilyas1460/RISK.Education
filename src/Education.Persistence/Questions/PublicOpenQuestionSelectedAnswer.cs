using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class PublicOpenQuestionSelectedAnswer : BaseEntity
{
    public int? PublicQuestionAnswerId { get; private set; }

    public string Answer { get; private set; }

    public virtual PublicQuestionAnswer? PublicQuestionAnswer { get; private set; }
}
