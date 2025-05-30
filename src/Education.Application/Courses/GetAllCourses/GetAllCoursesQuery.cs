using MediatR;

namespace Education.Application.Courses.GetAllCourses;

public sealed record GetAllCoursesQuery : IRequest<GetAllCoursesQueryResponse>;
