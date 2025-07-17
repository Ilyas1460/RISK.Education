using Education.Persistence.Courses;
using MediatR;

namespace Education.Application.Courses.DeleteCourse;

internal sealed class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, DeleteCourseCommandResponse>
{
    private readonly ICourseRepository _courseRepository;

    public DeleteCourseCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<DeleteCourseCommandResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(request.CourseId, cancellationToken);

        _courseRepository.Delete(course!, cancellationToken);

        return new DeleteCourseCommandResponse(course!.Id);
    }
}
