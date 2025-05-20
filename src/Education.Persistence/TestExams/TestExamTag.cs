using Education.Persistence.Abstractions;
using Education.Persistence.Contents;

namespace Education.Persistence.TestExams;

public class TestExamTag : BaseEntity
{
    public int TestExamId { get; set; }

    public int TagId { get; set; }

    public virtual Tag Tag { get; set; }

    public virtual TestExam TestExam { get; set; }
}
