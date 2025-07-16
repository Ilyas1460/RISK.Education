using Education.Application.Categories.GetCategory;

namespace Education.Application.Categories.GetAllCategories;

public record GetAllCategoriesQueryResponse(IReadOnlyList<GetCategoryQueryResponse> Categories);
