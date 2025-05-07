using Education.Persistence.Users;

namespace Education.Persistence.TestExams;

public class TestExamHistory
{
    public int Id { get; set; }

    public Guid TestExamPassageToken { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? TestExamId { get; set; }

    public int? UserId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual TestExam? TestExam { get; set; }

    public virtual ICollection<TestExamHistoryUserQuestionAnswerLink> TestExamHistoryUserQuestionAnswerLinks { get; set; } = new List<TestExamHistoryUserQuestionAnswerLink>();

    public virtual User? User { get; set; }
}
