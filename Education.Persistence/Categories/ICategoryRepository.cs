namespace Education.Persistence.Categories;

public interface ICategoryRepository {
    Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    void Add(Category category, CancellationToken cancellationToken);
    
    void Update(Category category, CancellationToken cancellationToken);
    
    void Delete(Category category, CancellationToken cancellationToken);
}