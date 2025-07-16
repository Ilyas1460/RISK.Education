using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class QuestionImage : BaseEntity
{
    public string ImageUrl { get; set; } = null!;

    public string? ImageAlt { get; set; }

    public int Order { get; set; }

    public int QuestionId { get; set; }

    public virtual Question Question { get; set; } = null!;
}
