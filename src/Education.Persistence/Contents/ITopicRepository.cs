using Education.Persistence.Contents;

namespace Education.Persistence.Contents;

public interface ITopicRepository
{
    Task<Topic?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Topic?> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task<List<Topic>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Topic topic, CancellationToken cancellationToken);
    Task UpdateAsync(Topic topic);
    Task DeleteAsync(Topic topic);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
