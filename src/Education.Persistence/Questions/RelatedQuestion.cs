using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class RelatedQuestion : BaseEntity
{
    public string Question { get; private set; } = null!;

    public int QuestionType { get; private set; }

    public string? AudioUrl { get; private set; }

    public virtual ICollection<RelatedQuestionLink> RelatedQuestionLinks { get; private set; } = new List<RelatedQuestionLink>();
}
