using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class QuestionAnswerImage : BaseEntity
{
    public string ImageUrl { get; set; }

    public string? ImageAlt { get; set; }

    public int Order { get; set; }

    public int QuestionAnswerId { get; set; }

    public virtual QuestionAnswer QuestionAnswer { get; set; }
}
