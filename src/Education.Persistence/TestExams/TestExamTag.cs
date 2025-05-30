using Education.Persistence.Abstractions;
using Education.Persistence.Contents;

namespace Education.Persistence.TestExams;

public class TestExamTag : BaseEntity
{
    public int TestExamId { get; private set; }

    public int TagId { get; private set; }

    public virtual Tag Tag { get; private set; }

    public virtual TestExam TestExam { get; private set; }
}
