using Education.Persistence.Abstractions;
using Education.Persistence.Courses;

namespace Education.Persistence.Topics;

public class Topic : Entity {
	public Guid TopicId { get; init; }
	public string Title { get; private set; }
	public string Description { get; private set; }
	public int OrderNumber { get; private set; }
	public Guid CourseId { get; private set; }
	
	public Course Course { get; set; }
	
	public Topic(Guid topicId, string title, string description, int orderNumber, Guid courseId) {
		TopicId = topicId;
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
	
	public void UpdateCourseId(Guid courseId) {
		CourseId = courseId;
	}
}