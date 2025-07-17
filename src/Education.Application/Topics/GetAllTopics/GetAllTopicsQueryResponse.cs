using Education.Application.Topics.GetTopic;

namespace Education.Application.Topics.GetAllTopics;

public record GetAllTopicsQueryResponse(IReadOnlyList<GetTopicQueryResponse> Topics);
