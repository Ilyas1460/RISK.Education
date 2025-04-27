using Education.Persistence.Categories;
using Microsoft.EntityFrameworkCore;

namespace Education.Infrastructure.Repositories;

public sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.Categories
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _dbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<Category?> GetByTitleAsync(string title, CancellationToken cancellationToken = default) =>
        await _dbContext.Categories
            .FirstOrDefaultAsync(c => c.Title == title, cancellationToken);

    public void Add(Category category, CancellationToken cancellationToken = default) =>
        _dbContext.Categories.Add(category);

    public void Delete(Category category, CancellationToken cancellationToken = default) =>
        _dbContext.Categories.Remove(category);
}
