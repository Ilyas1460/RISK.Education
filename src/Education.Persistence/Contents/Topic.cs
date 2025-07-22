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

    private Topic(string name, string? description, int? courseId, int? orderInCourse)
    {
        Name = name;
        Description = description;
        CourseId = courseId;
        OrderInCourse = orderInCourse;
    }

    private Topic() { }

    public static Topic Create(string name, string? description, int? courseId, int? orderInCourse)
    {
        return new Topic(name, description, courseId, orderInCourse);
    }

    public void Update(string name)
    {
        Name = name;
    }
}
