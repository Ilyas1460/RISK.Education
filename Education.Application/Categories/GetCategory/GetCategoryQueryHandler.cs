using Education.Application.Abstractions.Messaging;
using Education.Persistence.Abstractions;
using Education.Persistence.Categories;

namespace Education.Application.Categories.GetCategory;

public class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryQueryHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<Result<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        Category? result = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        return result is not null
            ? Result.Success(result)
            : Result.Failure<Category>(CategoryErrors.NotFound(request.CategoryId));
    }
}
