using Education.Persistence.Abstractions;
using Education.Persistence.Courses;
using Education.Persistence.Quizes;
using Education.Persistence.Theories;
using Education.Persistence.Videos;

namespace Education.Persistence.Topics;

public class Topic : Entity {
	public int TopicId { get; init; }
	public string Title { get; private set; }
	public string Description { get; private set; }
	public int OrderNumber { get; private set; }
	public int CourseId { get; private set; }
	
	public Course Course { get; set; }

	public List<Theory> Theories { get; set; }
	public List<Video> Videos { get; set; }
	public List<Quiz> Quizzes { get; set; }

	public Topic(string title, string description, int orderNumber, int courseId) {
		Title = title;
		Description = description;
		OrderNumber = orderNumber;
		CourseId = courseId;
	}
	
	public void UpdateTitle(string title) {
		Title = title;
	}
	
	public void UpdateDescription(string description) {
		Description = description;
	}
	
	public void UpdateOrderNumber(int orderNumber) {
		OrderNumber = orderNumber;
	}
	
	public void UpdateCourseId(int courseId) {
		CourseId = courseId;
	}
}