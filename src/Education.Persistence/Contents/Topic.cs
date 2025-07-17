using Education.Persistence.Abstractions;
using Education.Persistence.Courses;
using Education.Persistence.Lessons;

namespace Education.Persistence.Contents;

public class Topic : BaseEntity
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public int? CourseId { get; set; }

    public int? OrderInCourse { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<TopicContent> TopicContents { get; set; } = new List<TopicContent>();
}
