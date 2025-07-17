using Education.Exceptions.Exceptions;
using Education.Persistence.Courses;
using FluentValidation;

namespace Education.Application.Courses.GetCourse;

internal sealed class GetCourseQueryValidator : AbstractValidator<GetCourseQuery>
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseQueryValidator(ICourseRepository courseRepository)
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
