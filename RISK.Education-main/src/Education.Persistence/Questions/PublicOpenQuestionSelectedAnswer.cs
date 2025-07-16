using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class PublicOpenQuestionSelectedAnswer : BaseEntity
{
    public int? PublicQuestionAnswerId { get; set; }

    public string Answer { get; set; }

    public virtual PublicQuestionAnswer? PublicQuestionAnswer { get; set; }
}
