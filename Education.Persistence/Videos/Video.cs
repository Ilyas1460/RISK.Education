using Education.Persistence.Abstractions;
using Education.Persistence.Topics;

namespace Education.Persistence.Videos;

public class Video : BaseEntity
{
    public string Title { get; private set; }
    public string Url { get; private set; }
    public int OrderNumber { get; private set; }
    public int TopicId { get; private set; }

    public virtual Topic Topic { get; set; }

    private Video(string title, string url, int orderNumber, int topicId)
    {
        Title = title;
        Url = url;
        OrderNumber = orderNumber;
        TopicId = topicId;
    }

    public static Video Create(string title, string url, int orderNumber, int topicId)
    {
        return new Video(title, url, orderNumber, topicId);
    }
}
