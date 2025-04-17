using Education.Persistence.Abstractions;
using Education.Persistence.Topics;

namespace Education.Persistence.Videos;

public class Video : Entity {
	public int VideoId { get; init; }
	public string Title { get; private set; }
	public string URL { get; private set; }
	public int OrderNumber { get; private set; }
	public int TopicId { get; private set; }
	
	public Topic Topic { get; set; }
	
	public Video(int videoId, string title, string url, int orderNumber, int topicId) {
		VideoId = videoId;
		Title = title;
		URL = url;
		OrderNumber = orderNumber;
		TopicId = topicId;
	}
	
	public void UpdateTitle(string title) {
		Title = title;
	}
	
	public void UpdateURL(string url) {
		URL = url;
	}
	
	public void UpdateOrderNumber(int orderNumber) {
		OrderNumber = orderNumber;
	}
	
	public void UpdateTopicId(int topicId) {
		TopicId = topicId;
	}
}