using Education.Persistence.Abstractions;
using Education.Persistence.Users;

namespace Education.Persistence.TestExams;

public class TestExamHistory : BaseEntity
{
    public Guid TestExamPassageToken { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? TestExamId { get; set; }

    public int? UserId { get; set; }

    public virtual TestExam? TestExam { get; set; }

    public virtual ICollection<TestExamHistoryUserQuestionAnswerLink> TestExamHistoryUserQuestionAnswerLinks { get; set; } = new List<TestExamHistoryUserQuestionAnswerLink>();

    public virtual User? User { get; set; }
}
