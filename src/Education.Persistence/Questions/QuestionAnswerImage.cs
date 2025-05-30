using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class QuestionAnswerImage : BaseEntity
{
    public string ImageUrl { get; private set; }

    public string? ImageAlt { get; private set; }

    public int Order { get; private set; }

    public int QuestionAnswerId { get; private set; }

    public virtual QuestionAnswer QuestionAnswer { get; private set; }
}
