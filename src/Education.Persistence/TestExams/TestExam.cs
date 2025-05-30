using Education.Persistence.Abstractions;
using Education.Persistence.Courses;

namespace Education.Persistence.TestExams;

public class TestExam : BaseEntity
{
    public string Title { get; private set; }

    public string? Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime? PublishDate { get; private set; }

    public int? CourseId { get; private set; }

    public int Duration { get; private set; }

    public int Status { get; private set; }

    public bool IsFree { get; private set; }

    public string? ExplanationUrl { get; private set; }

    public int Level { get; private set; }

    public int Order { get; private set; }

    public virtual Course? Course { get; private set; }

    public virtual ICollection<TestExamHistory> TestExamHistories { get; private set; } = new List<TestExamHistory>();

    public virtual ICollection<TestExamQuestionLink> TestExamQuestionLinks { get; private set; } = new List<TestExamQuestionLink>();

    public virtual ICollection<TestExamTag> TestExamTags { get; private set; } = new List<TestExamTag>();
}
