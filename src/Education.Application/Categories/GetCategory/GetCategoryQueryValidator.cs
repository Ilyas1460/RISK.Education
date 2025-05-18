using Education.Exceptions.Exceptions;
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
            .WithMessage("Category ID is required.")
            .GreaterThan(0)
            .WithMessage("Category ID must be greater than 0.");

        RuleFor(c => c.CategoryId)
            .MustAsync(DoesCategoryExist)
            .When(x => x.CategoryId > 0);
    }

    private async Task<bool> DoesCategoryExist(int categoryId, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId, cancellationToken);

        if (category is null)
        {
            throw new NotFoundException($"Category with ID {categoryId} not found.");
        }

        return true;
    }
}
