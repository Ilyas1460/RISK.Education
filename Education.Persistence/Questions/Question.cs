using Education.Persistence.Abstractions;

namespace Education.Persistence.Questions;

public class Question : Entity {
	public Guid QuestionId { get; init; }
	public string Content { get; private set; }
	
}