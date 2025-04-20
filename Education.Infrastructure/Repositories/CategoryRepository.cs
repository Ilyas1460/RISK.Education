using Education.Persistence.Categories;
using Microsoft.EntityFrameworkCore;

namespace Education.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository {
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext) {
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken) {
        return await _dbContext.Categories
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken) {
        return await _dbContext.Categories
            .FirstOrDefaultAsync(c => c.CategoryId == id, cancellationToken);
    }

    public void Add(Category category, CancellationToken cancellationToken) {
        _dbContext.Categories.Add(category);
    }

    public void Update(Category category, CancellationToken cancellationToken) {
        _dbContext.Categories.Update(category);
    }

    public void Delete(Category category, CancellationToken cancellationToken) {
        _dbContext.Categories.Remove(category);
    }
}