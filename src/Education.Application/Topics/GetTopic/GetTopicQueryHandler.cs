using Education.Persistence.Contents;
using MediatR;

namespace Education.Application.Topics.GetTopic;

internal sealed class GetTopicQueryHandler : IRequestHandler<GetTopicQuery, GetTopicQueryResponse>
{
    private readonly ITopicRepository _topicRepository;

    public GetTopicQueryHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<GetTopicQueryResponse> Handle(GetTopicQuery request, CancellationToken cancellationToken)
    {
        var result = await _topicRepository.GetByIdAsync(request.TopicId, cancellationToken);

        return new GetTopicQueryResponse(
            result!.Id,
            result.Name,
            result.Description,
            result.OrderInCourse,
            result.CourseId,
            result.CreatedAt,
            result.UpdatedAt);
    }
}
