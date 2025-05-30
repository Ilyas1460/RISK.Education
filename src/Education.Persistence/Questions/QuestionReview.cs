using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class QuestionReview : BaseEntity
{
    public string? Comment { get; private set; }

    public int QuestionReviewStatus { get; private set; }

    public int? QuestionId { get; private set; }

    public int QuestionBugStatus { get; private set; }

    public virtual Question? Question { get; private set; }
}
