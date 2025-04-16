using Education.Persistence.Abstractions;
using Education.Persistence.Topics;

namespace Education.Persistence.Videos;

public class Video : Entity {
	public Guid VideoId { get; init; }
	public string Title { get; private set; }
	public string URL { get; private set; }
	public Guid TopicId { get; private set; }
	
	public Topic Topic { get; set; }
	
	public Video(Guid videoId, string title, string url, Guid topicId) {
		VideoId = videoId;
		Title = title;
		URL = url;
		TopicId = topicId;
	}
	
	public void UpdateTitle(string title) {
		Title = title;
	}
	
	public void UpdateURL(string url) {
		URL = url;
	}
	
	public void UpdateTopicId(Guid topicId) {
		TopicId = topicId;
	}
}