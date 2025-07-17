using MediatR;

namespace Education.Application.Courses.DeleteCourse;

public sealed record DeleteCourseCommand(int CourseId) : IRequest<DeleteCourseCommandResponse>;
