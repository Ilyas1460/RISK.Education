using Education.Application.Topics.GetTopic;
using Education.Persistence.Contents;
using MediatR;

namespace Education.Application.Topics.GetAllTopics;

internal sealed class GetAllTopicsQueryHandler : IRequestHandler<GetAllTopicsQuery, GetAllTopicsQueryResponse>
{
    private readonly ITopicRepository _topicRepository;

    public GetAllTopicsQueryHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<GetAllTopicsQueryResponse> Handle(GetAllTopicsQuery request, CancellationToken cancellationToken)
    {
        var topics = await _topicRepository.GetAllAsync(cancellationToken);

        var responseTopics = topics
            .Select(t => new GetTopicQueryResponse(
                t.Id,
                t.Name,
                t.Description,
                t.OrderInCourse,
                t.CourseId,
                t.CreatedAt,
                t.UpdatedAt))
            .ToList();

        return new GetAllTopicsQueryResponse(responseTopics);
    }
}
