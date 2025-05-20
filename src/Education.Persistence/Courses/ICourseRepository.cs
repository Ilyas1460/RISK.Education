namespace Education.Persistence.Courses;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Course?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(Course course, CancellationToken cancellationToken = default);

    void Delete(Course course, CancellationToken cancellationToken = default);
}
