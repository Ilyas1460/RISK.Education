using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class RelatedQuestionLink : BaseEntity
{
    public int Order { get; set; }

    public int? RelatedQuestionId { get; set; }

    public int? QuestionId { get; set; }

    public virtual Question? Question { get; set; }

    public virtual RelatedQuestion? RelatedQuestion { get; set; }
}
