using Education.Persistence.Courses;
using Microsoft.EntityFrameworkCore;

namespace Education.Infrastructure.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Course>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Courses
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Course?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _dbContext.Courses
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public void Add(Course course, CancellationToken cancellationToken = default) =>
        _dbContext.Courses.Add(course);

    public void Delete(Course course, CancellationToken cancellationToken = default) =>
        _dbContext.Courses.Remove(course);
}
