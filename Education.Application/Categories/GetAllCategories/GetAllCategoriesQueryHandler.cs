using Education.Application.Abstractions.Messaging;
using Education.Persistence.Abstractions;
using Education.Persistence.Categories;

namespace Education.Application.Categories.GetAllCategories;

public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, IEnumerable<Category>> {
    private readonly ICategoryRepository _categoryRepository;
    
    public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository) {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<Result<IEnumerable<Category>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken) {
        var result = await _categoryRepository.GetAllAsync(cancellationToken);

        return Result.Success(result);
    }
}