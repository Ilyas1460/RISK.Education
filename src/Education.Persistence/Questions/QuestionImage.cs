using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class QuestionImage : BaseEntity
{
    public string ImageUrl { get; private set; } = null!;

    public string? ImageAlt { get; private set; }

    public int Order { get; private set; }

    public int QuestionId { get; private set; }

    public virtual Question Question { get; private set; } = null!;
}
