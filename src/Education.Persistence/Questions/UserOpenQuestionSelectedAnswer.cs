using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class UserOpenQuestionSelectedAnswer : BaseEntity
{
    public int? UserQuestionAnswerId { get; set; }

    public string Answer { get; set; } = null!;

    public virtual UserQuestionAnswer? UserQuestionAnswer { get; set; }
}
