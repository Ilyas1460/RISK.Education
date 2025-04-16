using Education.Persistence.Abstractions;
using Education.Persistence.Topics;

namespace Education.Persistence.Theories;

public class Theory : Entity {
	public Guid TheoryId { get; init; }
	public string Title { get; private set; }
	public string Content { get; private set; }
	public Guid TopicId { get; private set; }
	
	public Topic Topic { get; set; }
	
	public Theory(Guid theoryId, string title, string content, Guid topicId) {
		TheoryId = theoryId;
		Title = title;
		Content = content;
		TopicId = topicId;
	}
	
	public void UpdateTitle(string title) {
		Title = title;
	}
	
	public void UpdateContent(string content) {
		Content = content;
	}
	
	public void UpdateTopicId(Guid topicId) {
		TopicId = topicId;
	}
}