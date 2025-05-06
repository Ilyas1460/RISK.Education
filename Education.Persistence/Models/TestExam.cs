namespace Education.Persistence.Models;

public partial class TestExam
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime? PublishDate { get; set; }

    public int? CourseId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int Duration { get; set; }

    public int Status { get; set; }

    public bool IsFree { get; set; }

    public string? ExplanationUrl { get; set; }

    public int Level { get; set; }

    public int Order { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<TestExamHistory> TestExamHistories { get; set; } = new List<TestExamHistory>();

    public virtual ICollection<TestExamQuestionLink> TestExamQuestionLinks { get; set; } = new List<TestExamQuestionLink>();

    public virtual ICollection<TestExamTag> TestExamTags { get; set; } = new List<TestExamTag>();
}
