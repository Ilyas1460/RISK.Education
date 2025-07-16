using MediatR;
using Education.Persistence.Contents;

namespace Education.Application.Topics.DeleteTopic;

public class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand, DeleteTopicCommandResponse>
{
    private readonly ITopicRepository _topicRepository;

    public DeleteTopicCommandHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<DeleteTopicCommandResponse> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetByIdAsync(request.Id, cancellationToken);

        if (topic == null)
        {
            throw new Exception($"Topic with Id {request.Id} was not found.");
        }

        await _topicRepository.DeleteAsync(topic);

        await _topicRepository.SaveChangesAsync(cancellationToken);

        return new DeleteTopicCommandResponse { Id = topic.Id };
    }
}
