using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class RelatedQuestion : BaseEntity
{
    public string Question { get; set; } = null!;

    public int QuestionType { get; set; }

    public string? AudioUrl { get; set; }

    public virtual ICollection<RelatedQuestionLink> RelatedQuestionLinks { get; set; } = new List<RelatedQuestionLink>();
}
