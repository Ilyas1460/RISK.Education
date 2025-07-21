using Education.Exceptions.Exceptions;
using Education.Persistence.Contents;
using Education.Persistence.Courses;
using FluentValidation;

namespace Education.Application.Topics.CreateTopic;

internal sealed class CreateTopicCommandValidator : AbstractValidator<CreateTopicCommand>
{
    private readonly ICourseRepository _courseRepository;

    public CreateTopicCommandValidator(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;

        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Topic name is required.");

        RuleFor(x => x.CourseId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("CourseId is required.")
            .MustAsync(CourseExists)
            .WithMessage("Provided course does not exist.");
    }

    private async Task<bool> CourseExists(int courseId, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(courseId, cancellationToken);
        return course is not null;
    }
}
