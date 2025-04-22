using Education.Persistence.Abstractions;

namespace Education.Infrastructure.Repositories;

public abstract class Repository<T> where T : Entity
{
    protected readonly ApplicationDbContext _dbContext;

    protected Repository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public virtual void Add(T entity) => _dbContext.Set<T>().Add(entity);
}
