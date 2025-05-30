using Education.Persistence.Abstractions;
using Education.Persistence.Questions;

namespace Education.Persistence.TestExams;

public class TestExamHistoryUserQuestionAnswerLink : BaseEntity
{
    public int? UserQuestionAnswerId { get; private set; }

    public int TestExamHistoryId { get; private set; }

    public virtual TestExamHistory TestExamHistory { get; private set; } = null!;

    public virtual UserQuestionAnswer? UserQuestionAnswer { get; private set; }
}
