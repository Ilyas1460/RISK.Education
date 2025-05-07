namespace Education.Persistence.Questions;

public class PublicOpenQuestionSelectedAnswer
{
    public int Id { get; set; }

    public int? PublicQuestionAnswerId { get; set; }

    public string Answer { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual PublicQuestionAnswer? PublicQuestionAnswer { get; set; }
}
