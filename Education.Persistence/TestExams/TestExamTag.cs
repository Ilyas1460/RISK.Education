using Education.Persistence.Contents;

namespace Education.Persistence.TestExams;

public class TestExamTag
{
    public int Id { get; set; }

    public int TestExamId { get; set; }

    public int TagId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Tag Tag { get; set; } = null!;

    public virtual TestExam TestExam { get; set; } = null!;
}
