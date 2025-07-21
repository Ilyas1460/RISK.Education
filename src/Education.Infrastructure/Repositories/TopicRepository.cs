using Education.Persistence.Contents;
using Microsoft.EntityFrameworkCore;

namespace Education.Infrastructure.Repositories;

public class TopicRepository : Repository<Topic>, ITopicRepository
{
    public TopicRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Topic?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Topics.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<Topic?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbContext.Topics.FirstOrDefaultAsync(t => t.Name == name, cancellationToken);
    }

    public async Task<List<Topic>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Topics
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);
    }

    public Task DeleteAsync(Topic topic)
    {
        _dbContext.Topics.Remove(topic);
        return Task.CompletedTask;
    }
}
