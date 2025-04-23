using Education.Persistence.Abstractions;
using Education.Persistence.Questions;
using Education.Persistence.Topics;

namespace Education.Persistence.Quizzes;

public sealed class Quiz : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int OrderNumber { get; private set; }
    public int TopicId { get; private set; }

    public Topic Topic { get; set; }

    public List<Question> Questions { get; set; }

    private Quiz(string title, string description, int orderNumber, int topicId)
    {
        Title = title;
        Description = description;
        OrderNumber = orderNumber;
        TopicId = topicId;
    }

    public static Quiz Create(string title, string description, int orderNumber, int topicId)
    {
        return new Quiz(title, description, orderNumber, topicId);
    }

    public void UpdateTitle(string title) => Title = title;

    public void UpdateDescription(string description) => Description = description;

    public void UpdateOrderNumber(int orderNumber) => OrderNumber = orderNumber;

    public void UpdateTopicId(int topicId) => TopicId = topicId;
}
