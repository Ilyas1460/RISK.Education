using Education.Persistence.Abstractions;
using Education.Persistence.Questions;

namespace Education.Persistence.TestExams;

public class TestExamHistoryUserQuestionAnswerLink : BaseEntity
{
    public int? UserQuestionAnswerId { get; set; }

    public int TestExamHistoryId { get; set; }

    public virtual TestExamHistory TestExamHistory { get; set; } = null!;

    public virtual UserQuestionAnswer? UserQuestionAnswer { get; set; }
}
