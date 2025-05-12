using Education.Application.Abstractions.Messaging;
using Education.Persistence.Categories;

namespace Education.Application.Categories.GetCategory;

internal sealed class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, GetCategoryQueryResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryQueryHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<GetCategoryQueryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        return new GetCategoryQueryResponse(
            result!.Id,
            result.Title,
            result.Description,
            result.CreatedAt,
            result.UpdatedAt);
    }
}
