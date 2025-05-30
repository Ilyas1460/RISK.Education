using Education.Persistence.Abstractions;
using Education.Persistence.Users;

namespace Education.Persistence.TestExams;

public class TestExamHistory : BaseEntity
{
    public Guid TestExamPassageToken { get; private set; }

    public DateTime StartTime { get; private set; }

    public DateTime? EndTime { get; private set; }

    public int? TestExamId { get; private set; }

    public int? UserId { get; private set; }

    public virtual TestExam? TestExam { get; private set; }

    public virtual ICollection<TestExamHistoryUserQuestionAnswerLink> TestExamHistoryUserQuestionAnswerLinks { get; private set; } = new List<TestExamHistoryUserQuestionAnswerLink>();

    public virtual User? User { get; private set; }
}
