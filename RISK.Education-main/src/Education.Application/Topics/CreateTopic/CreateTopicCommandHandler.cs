using Education.Persistence.Contents;
using MediatR;

namespace Education.Application.Topics.CreateTopic;

internal sealed class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, CreateTopicCommandResponse>
{
    private readonly ITopicRepository _topicRepository;

    public CreateTopicCommandHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<CreateTopicCommandResponse> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var newTopic = new Topic
        {
            Name = request.Name,
            Description = request.Description,
            OrderInCourse = request.OrderInCourse,
            CourseId = request.CourseId
        };

        await _topicRepository.AddAsync(newTopic, cancellationToken);

        return new CreateTopicCommandResponse(newTopic.Id);
    }
}
