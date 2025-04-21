using Education.Application.Abstractions.Messaging;
using Education.Persistence.Abstractions;
using Education.Persistence.Categories;

namespace Education.Application.Categories.GetACategory;

public class GetACategoryQueryHandler : IQueryHandler<GetACategoryQuery, Category> {
    private readonly ICategoryRepository _categoryRepository;
    
    public GetACategoryQueryHandler(ICategoryRepository categoryRepository) {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<Result<Category>> Handle(GetACategoryQuery request, CancellationToken cancellationToken) {
        var result = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
        
        return result is not null
            ? Result.Success(result)
            : Result.Failure<Category>(CategoryErrors.NotFound(request.CategoryId));
    }
}