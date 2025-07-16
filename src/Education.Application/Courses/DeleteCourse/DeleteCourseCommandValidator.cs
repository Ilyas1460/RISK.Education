using Education.Exceptions.Exceptions;
using Education.Persistence.Courses;
using FluentValidation;

namespace Education.Application.Courses.DeleteCourse;

internal sealed class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
{
    private readonly ICourseRepository _courseRepository;

    public DeleteCourseCommandValidator(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;

        RuleFor(x => x.CourseId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Course ID must not be empty.")
            .MustAsync(DoesCourseExist);
    }

    private async Task<bool> DoesCourseExist(int courseId, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(courseId, cancellationToken);

        if (course is null)
        {
            throw new NotFoundException($"Course with ID {courseId} not found.");
        }

        return true;
    }
}
