namespace Education.Persistence.Models;

public partial class TestExamQuestionLink
{
    public int Id { get; set; }

    public int Order { get; set; }

    public int? TestExamId { get; set; }

    public int? QuestionId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Question? Question { get; set; }

    public virtual TestExam? TestExam { get; set; }
}
