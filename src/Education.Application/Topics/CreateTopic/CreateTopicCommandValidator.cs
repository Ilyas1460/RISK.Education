using Education.Exceptions.Exceptions;
using Education.Persistence.Contents;
using FluentValidation;

namespace Education.Application.Topics.CreateTopic;

internal sealed class CreateTopicCommandValidator : AbstractValidator<CreateTopicCommand>
{
    private readonly ITopicRepository _topicRepository;

    public CreateTopicCommandValidator(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;

        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Topic name is required.")
            .MustAsync(IsUniqueName);

        RuleFor(x => x.CourseId)
            .GreaterThan(0).When(x => x.CourseId.HasValue);
    }

    private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetByNameAsync(name, cancellationToken);

        if (topic is not null)
        {
            throw new ConflictException("Topic with name '{0}' already exists.", name);
        }

        return true;
    }
}
