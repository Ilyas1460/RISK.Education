using Education.Persistence.Abstractions;
using Education.Persistence.Courses;
using Education.Persistence.Quizzes;
using Education.Persistence.Theories;
using Education.Persistence.Videos;

namespace Education.Persistence.Topics;

public class Topic : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int OrderNumber { get; private set; }
    public int CourseId { get; private set; }

    public virtual Course Course { get; set; }

    public virtual List<Theory> Theories { get; set; }
    public virtual List<Video> Videos { get; set; }
    public virtual List<Quiz> Quizzes { get; set; }

    private Topic(string title, string description, int orderNumber, int courseId)
    {
        Title = title;
        Description = description;
        OrderNumber = orderNumber;
        CourseId = courseId;
    }

    public static Topic Create(string title, string description, int orderNumber, int courseId)
    {
        return new Topic(title, description, orderNumber, courseId);
    }
}
