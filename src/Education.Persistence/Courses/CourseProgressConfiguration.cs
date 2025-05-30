using Education.Persistence.Abstractions;

namespace Education.Persistence.Courses;

public class CourseProgressConfiguration : BaseEntity
{
    public int? LevelId { get; private set; }

    public int Component { get; private set; }

    public double Weight { get; private set; }

    public virtual CourseProgressLevel? Level { get; private set; }
}
