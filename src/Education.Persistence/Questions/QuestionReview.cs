using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class QuestionReview : BaseEntity
{
    public string? Comment { get; set; }

    public int QuestionReviewStatus { get; set; }

    public int? QuestionId { get; set; }

    public int QuestionBugStatus { get; set; }

    public virtual Question? Question { get; set; }
}
