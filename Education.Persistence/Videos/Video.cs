using Education.Persistence.Abstractions;
using Education.Persistence.Topics;

namespace Education.Persistence.Videos;

public sealed class Video : BaseEntity
{
    public string Title { get; private set; }
    public string Url { get; private set; }
    public int OrderNumber { get; private set; }
    public int TopicId { get; private set; }

    public Topic Topic { get; set; }

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

    public void UpdateTitle(string title) => Title = title;

    public void UpdateURL(string url) => Url = url;

    public void UpdateOrderNumber(int orderNumber) => OrderNumber = orderNumber;

    public void UpdateTopicId(int topicId) => TopicId = topicId;
}
