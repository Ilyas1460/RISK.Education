using MediatR;

namespace Education.Application.Courses.GetAllCourses;

public record GetAllCoursesQuery : IRequest<GetAllCoursesQueryResponse>;
