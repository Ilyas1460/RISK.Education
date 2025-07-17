using Education.Persistence.Contents;
using Microsoft.EntityFrameworkCore;

namespace Education.Infrastructure.Repositories;

public class TopicRepository : ITopicRepository
{
    private readonly ApplicationDbContext _context;

    public TopicRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Topic?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Topics.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<Topic?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _context.Topics.FirstOrDefaultAsync(t => t.Name == name, cancellationToken);
    }

    public async Task<List<Topic>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Topics.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Topic topic, CancellationToken cancellationToken)
    {
        await _context.Topics.AddAsync(topic, cancellationToken);
    }

    public Task UpdateAsync(Topic topic)
    {
        _context.Topics.Update(topic);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Topic topic)
    {
        _context.Topics.Remove(topic);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
