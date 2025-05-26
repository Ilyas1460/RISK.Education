using Education.Application.Courses.GetCourse;

namespace Education.Application.Courses.GetAllCourses;

public record GetAllCoursesQueryResponse(IReadOnlyList<GetCourseQueryResponse> Courses);
