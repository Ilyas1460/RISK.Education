using Education.Persistence.TestExams;

namespace Education.Persistence.Contents;

public class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<TestExamTag> TestExamTags { get; set; } = new List<TestExamTag>();
}
