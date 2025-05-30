using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class UserStandardQuestionSelectedAnswer : BaseEntity
{
    public int? UserQuestionAnswerId { get; private set; }

    public int UserSelectedAnswerId { get; private set; }

    public virtual UserQuestionAnswer? UserQuestionAnswer { get; private set; }

    public virtual QuestionAnswer UserSelectedAnswer { get; private set; } = null!;
}
