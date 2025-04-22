using Education.Persistence.Categories;
using MediatR;

namespace Education.Application.Categories.GetCategory;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryQueryHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        Category? result = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        return result ?? throw new InvalidOperationException($"Category with ID {request.CategoryId} not found.");
    }
}
