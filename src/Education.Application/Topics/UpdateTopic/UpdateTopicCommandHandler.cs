using MediatR;
using Education.Persistence.Contents;
using Education.Application.Exceptions;

namespace Education.Application.Topics.UpdateTopic;

public sealed class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommand, UpdateTopicCommandResponse>
{
    private readonly ITopicRepository _topicRepository;

    public UpdateTopicCommandHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<UpdateTopicCommandResponse> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetByIdAsync(request.TopicId, cancellationToken);

        if (topic is null)
        {
            throw new NotFoundException(nameof(Topic), request.TopicId);
        }

        topic.Name = request.Name;
        topic.Description = request.Description;
        topic.OrderInCourse = request.OrderInCourse;

        await _topicRepository.UpdateAsync(topic, cancellationToken);

        return new UpdateTopicCommandResponse(topic.Id);
    }
}
