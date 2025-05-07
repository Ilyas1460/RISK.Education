namespace Education.Persistence.Questions;

public class PublicStandardQuestionSelectedAnswer
{
    public int Id { get; set; }

    public int? PublicQuestionAnswerId { get; set; }

    public int SelectedAnswerId { get; set; }

    public int? QuestionAnswerId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual PublicQuestionAnswer? PublicQuestionAnswer { get; set; }

    public virtual QuestionAnswer? QuestionAnswer { get; set; }
}
