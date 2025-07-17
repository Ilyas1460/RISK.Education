using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class PublicStandardQuestionSelectedAnswer : BaseEntity
{
    public int? PublicQuestionAnswerId { get; set; }

    public int SelectedAnswerId { get; set; }

    public int? QuestionAnswerId { get; set; }

    public virtual PublicQuestionAnswer? PublicQuestionAnswer { get; set; }

    public virtual QuestionAnswer? QuestionAnswer { get; set; }
}
