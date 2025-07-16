using FluentValidation;
using Education.Persistence.Contents;

namespace Education.Application.Topics.DeleteTopic;

internal sealed class DeleteTopicCommandValidator : AbstractValidator<DeleteTopicCommand>
{
    private readonly ITopicRepository _topicRepository;

    public DeleteTopicCommandValidator(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;

        RuleFor(x => x.Id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Topic ID must not be empty.")
            .MustAsync(DoesTopicExist);
    }

    private async Task<bool> DoesTopicExist(int topicId, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetByIdAsync(topicId, cancellationToken);

        return topic != null;
    }
}
