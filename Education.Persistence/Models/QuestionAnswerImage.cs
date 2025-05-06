namespace Education.Persistence.Models;

public partial class QuestionAnswerImage
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? ImageAlt { get; set; }

    public int Order { get; set; }

    public int QuestionAnswerId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual QuestionAnswer QuestionAnswer { get; set; } = null!;
}
