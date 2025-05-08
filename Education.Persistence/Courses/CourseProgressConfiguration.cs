using Education.Persistence.Abstractions;

namespace Education.Persistence.Courses;

public class CourseProgressConfiguration : BaseEntity
{
    public int? LevelId { get; set; }

    public int Component { get; set; }

    public double Weight { get; set; }

    public virtual CourseProgressLevel? Level { get; set; }
}
