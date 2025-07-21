using MediatR;
using Education.Application.Exceptions;
using Education.Persistence.Contents;

namespace Education.Application.Topics.DeleteTopic;

public sealed class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand>
{
    private readonly ITopicRepository _topicRepository;

    public DeleteTopicCommandHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetByIdAsync(request.TopicId, cancellationToken);

        if (topic is null)
        {
            throw new NotFoundException(nameof(Topic), request.TopicId);
        }

        await _topicRepository.DeleteAsync(topic, cancellationToken);
    }
}
