namespace Education.Persistence.Models;

public partial class TestExamHistoryUserQuestionAnswerLink
{
    public int Id { get; set; }

    public int? UserQuestionAnswerId { get; set; }

    public int TestExamHistoryId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual TestExamHistory TestExamHistory { get; set; } = null!;

    public virtual UserQuestionAnswer? UserQuestionAnswer { get; set; }
}
