using MediatR;

namespace Education.Application.Topics.GetTopic;

public sealed record GetTopicQuery(int TopicId) : IRequest<GetTopicQueryResponse>;
