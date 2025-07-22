using Education.Persistence.Contents;
using MediatR;

namespace Education.Application.Topics.DeleteTopic;

internal sealed class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand, DeleteTopicCommandResponse>
{
    private readonly ITopicRepository _topicRepository;

    public DeleteTopicCommandHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<DeleteTopicCommandResponse> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetByIdAsync(request.Id, cancellationToken);

        _topicRepository.Delete(topic);

        return new DeleteTopicCommandResponse();
    }
}
