using Education.Persistence.Categories;
using FluentValidation;

namespace Education.Application.Categories.GetCategory;

internal sealed class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryQueryValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(c => c.CategoryId)
            .NotEmpty()
            .WithMessage("CategoryId is required.")
            .GreaterThan(0)
            .WithMessage("CategoryId must be greater than 0.")
            .MustAsync(DoesCategoryExist)
            .WithMessage("Category with the specified ID does not exist.");
    }

    private async Task<bool> DoesCategoryExist(int id, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        return category is not null;
    }
}
