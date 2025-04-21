using Education.Persistence.Abstractions;
using Education.Persistence.Topics;

namespace Education.Persistence.Theories;

public class Theory : Entity {
	public int TheoryId { get; init; }
	public string Title { get; private set; }
	public string Content { get; private set; }
	public int OrderNumber { get; private set; }
	public int TopicId { get; private set; }
	
	public Topic Topic { get; set; }
	
	public Theory(string title, string content, int orderNumber, int topicId) {
		Title = title;
		Content = content;
		OrderNumber = orderNumber;
		TopicId = topicId;
	}
	
	public void UpdateTitle(string title) {
		Title = title;
	}
	
	public void UpdateContent(string content) {
		Content = content;
	}
	
	public void UpdateOrderNumber(int orderNumber) {
		OrderNumber = orderNumber;
	}
	
	public void UpdateTopicId(int topicId) {
		TopicId = topicId;
	}
}