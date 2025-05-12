using Education.Persistence.Abstractions;
using Education.Persistence.TestExams;

namespace Education.Persistence.Contents;

public class Tag : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<TestExamTag> TestExamTags { get; set; } = new List<TestExamTag>();
}
