using Education.Persistence.Abstractions;
using Education.Persistence.Courses;
using Education.Persistence.Lessons;

namespace Education.Persistence.Contents;

public class Topic : BaseEntity
{
    public string Name { get; private set; }

    public string? Description { get; private set; }

    public int? CourseId { get; private set; }

    public int? OrderInCourse { get; private set; }

    public virtual Course? Course { get; private set; }

    public virtual ICollection<Lesson> Lessons { get; private set; } = new List<Lesson>();

    public virtual ICollection<TopicContent> TopicContents { get; private set; } = new List<TopicContent>();

    private Topic() { } // Required for EF Core

    public static Topic Create(string name, int? courseId)
    {
        return new Topic
        {
            Name = name,
            CourseId = courseId
        };
    }

    public void Update(string name)
    {
        Name = name;
    }
}
