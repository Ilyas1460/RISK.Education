using Education.Persistence.Abstractions;
using Education.Persistence.Questions;

namespace Education.Persistence.TestExams;

public class TestExamQuestionLink : BaseEntity
{
    public int Order { get; set; }

    public int? TestExamId { get; set; }

    public int? QuestionId { get; set; }

    public virtual Question? Question { get; set; }

    public virtual TestExam? TestExam { get; set; }
}
