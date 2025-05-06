namespace Education.Persistence.Models;

public partial class RelatedQuestion
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public int QuestionType { get; set; }

    public string? AudioUrl { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<RelatedQuestionLink> RelatedQuestionLinks { get; set; } = new List<RelatedQuestionLink>();
}
