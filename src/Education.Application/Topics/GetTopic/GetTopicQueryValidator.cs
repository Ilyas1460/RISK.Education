using Education.Exceptions.Exceptions;
using Education.Persistence.Contents;
using FluentValidation;

namespace Education.Application.Topics.GetTopic;

internal sealed class GetTopicQueryValidator : AbstractValidator<GetTopicQuery>
{
    private readonly ITopicRepository _topicRepository;

    public GetTopicQueryValidator(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;

        RuleFor(t => t.TopicId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Topic ID must not be empty.")
            .MustAsync(DoesTopicExist);
    }

    private async Task<bool> DoesTopicExist(int topicId, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetByIdAsync(topicId, cancellationToken);

        if (topic is null)
        {
            throw new NotFoundException("Topic with ID {0} not found.", topicId);
        }

        return true;
    }
}
