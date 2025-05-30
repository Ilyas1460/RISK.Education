using Education.Persistence.Abstractions;
using Education.Persistence.TestExams;

namespace Education.Persistence.Contents;

public class Tag : BaseEntity
{
    public string Name { get; private set; }

    public virtual ICollection<TestExamTag> TestExamTags { get; private set; } = new List<TestExamTag>();
}
