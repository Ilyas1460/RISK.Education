using Education.Persistence.Abstractions;
using Education.Persistence.Topics;

namespace Education.Persistence.Quizes;

public class Quiz : Entity {
	public Guid QuizId { get; init; }
	public string Title { get; private set; }
	public string Description { get; private set; }
	public Guid TopicId { get; private set; }
	
	public Topic Topic { get; set; }
	
	public Quiz(Guid quizId, string title, string description, Guid topicId) {
		QuizId = quizId;
		Title = title;
		Description = description;
		TopicId = topicId;
	}
	
	public void UpdateTitle(string title) {
		Title = title;
	}
	
	public void UpdateDescription(string description) {
		Description = description;
	}
	
	public void UpdateTopicId(Guid topicId) {
		TopicId = topicId;
	}
}