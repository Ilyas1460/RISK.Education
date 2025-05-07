using Education.Persistence.Courses;
using Education.Persistence.Lessons;

namespace Education.Persistence.Contents;

public class Topic
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? CourseId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? OrderInCourse { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<TopicContent> TopicContents { get; set; } = new List<TopicContent>();
}
