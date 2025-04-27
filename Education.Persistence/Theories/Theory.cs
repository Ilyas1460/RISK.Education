using Education.Persistence.Abstractions;
using Education.Persistence.Topics;

namespace Education.Persistence.Theories;

public sealed class Theory : BaseEntity
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public int OrderNumber { get; private set; }
    public int TopicId { get; private set; }

    public Topic Topic { get; set; }

    private Theory(string title, string content, int orderNumber, int topicId)
    {
        Title = title;
        Content = content;
        OrderNumber = orderNumber;
        TopicId = topicId;
    }

    public static Theory Create(string title, string content, int orderNumber, int topicId)
    {
        return new Theory(title, content, orderNumber, topicId);
    }
}
