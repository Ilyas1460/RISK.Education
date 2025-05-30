using Education.Persistence.Abstractions;
using Education.Persistence.Questions;

namespace Education.Persistence.TestExams;

public class TestExamQuestionLink : BaseEntity
{
    public int Order { get; private set; }

    public int? TestExamId { get; private set; }

    public int? QuestionId { get; private set; }

    public virtual Question? Question { get; private set; }

    public virtual TestExam? TestExam { get; private set; }
}
