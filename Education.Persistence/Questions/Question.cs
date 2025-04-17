using Education.Persistence.Abstractions;
using Education.Persistence.Answers;
using Education.Persistence.Courses;
using Education.Persistence.Quizes;

namespace Education.Persistence.Questions;

public class Question : Entity {
	public int QuestionId { get; init; }
	public string Content { get; private set; }
	public QuestionType Type { get; private set; }
	public int CourseId { get; private set; }
	
	public Course Course { get; set; }
	
	public List<Answer> Answers { get; set; }
	public List<Quiz> Quizzes { get; set; }
	
	public Question(int questionId, string content, QuestionType type, int courseId) {
		QuestionId = questionId;
		Content = content;
		Type = type;
		CourseId = courseId;
	}
	
	public void UpdateContent(string content) {
		Content = content;
	}
	
	public void UpdateType(QuestionType type) {
		Type = type;
	}
	
	public void UpdateCourseId(int courseId) {
		CourseId = courseId;
	}
}