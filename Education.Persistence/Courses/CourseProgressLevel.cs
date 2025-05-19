using Education.Persistence.Abstractions;

namespace Education.Persistence.Courses;

public class CourseProgressLevel : BaseEntity
{
    public string Name { get; set; } = null!;

    public int Order { get; set; }

    public virtual ICollection<CourseProgressConfiguration> CourseProgressConfigurations { get; set; } = new List<CourseProgressConfiguration>();
}
