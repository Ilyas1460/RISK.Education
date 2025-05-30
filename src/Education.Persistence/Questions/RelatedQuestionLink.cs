using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class RelatedQuestionLink : BaseEntity
{
    public int Order { get; private set; }

    public int? RelatedQuestionId { get; private set; }

    public int? QuestionId { get; private set; }

    public virtual Question? Question { get; private set; }

    public virtual RelatedQuestion? RelatedQuestion { get; private set; }
}
