using Education.Persistence.Abstractions;

namespace Education.Persistence.Courses;

public class CourseProgressLevel : BaseEntity
{
    public string Name { get; private set; } = null!;

    public int Order { get; private set; }

    public virtual ICollection<CourseProgressConfiguration> CourseProgressConfigurations { get; private set; } = new List<CourseProgressConfiguration>();
}
