using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class UserOpenQuestionSelectedAnswer : BaseEntity
{
    public int? UserQuestionAnswerId { get; private set; }

    public string Answer { get; private set; } = null!;

    public virtual UserQuestionAnswer? UserQuestionAnswer { get; private set; }
}
