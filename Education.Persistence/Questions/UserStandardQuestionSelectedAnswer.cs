using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class UserStandardQuestionSelectedAnswer : BaseEntity
{
    public int? UserQuestionAnswerId { get; set; }

    public int UserSelectedAnswerId { get; set; }

    public virtual UserQuestionAnswer? UserQuestionAnswer { get; set; }

    public virtual QuestionAnswer UserSelectedAnswer { get; set; } = null!;
}
