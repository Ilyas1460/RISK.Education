using MediatR;
using Education.Persistence.Contents;

namespace Education.Application.Topics.UpdateTopic;

public class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommand, UpdateTopicCommandResponse>
{
    private readonly ITopicRepository _topicRepository;

    public UpdateTopicCommandHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<UpdateTopicCommandResponse> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetByIdAsync(request.TopicId, cancellationToken);

        if (topic == null)
        {
            throw new Exception($"Topic with Id {request.TopicId} was not found.");
        }

        topic.Name = request.Name;

        await _topicRepository.UpdateAsync(topic);
        await _topicRepository.SaveChangesAsync(cancellationToken);

        return new UpdateTopicCommandResponse(topic.Id);
    }
}
