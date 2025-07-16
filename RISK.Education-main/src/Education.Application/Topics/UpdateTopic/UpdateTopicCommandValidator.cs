using Education.Exceptions.Exceptions;
using Education.Persistence.Contents;
using FluentValidation;

namespace Education.Application.Topics.UpdateTopic;

internal sealed class UpdateTopicCommandValidator : AbstractValidator<UpdateTopicCommand>
{
    private readonly ITopicRepository _topicRepository;

    public UpdateTopicCommandValidator(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;

        RuleFor(x => x.TopicId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Topic ID must not be empty.")
            .MustAsync(DoesTopicExist);

        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MustAsync((command, name, cancellationToken) => IsUniqueName(command.TopicId, name, cancellationToken));
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

    private async Task<bool> IsUniqueName(int topicId, string name, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetByNameAsync(name, cancellationToken);

        if (topic is not null && topic.Id != topicId)
        {
            throw new ConflictException("Topic with name '{0}' already exists.", name);
        }

        return true;
    }
}
