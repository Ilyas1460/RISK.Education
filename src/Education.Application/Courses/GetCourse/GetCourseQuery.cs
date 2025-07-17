using MediatR;

namespace Education.Application.Courses.GetCourse;

public sealed record GetCourseQuery(int CourseId) : IRequest<GetCourseQueryResponse>;
