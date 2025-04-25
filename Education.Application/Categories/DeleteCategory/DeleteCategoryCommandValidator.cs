using Education.Persistence.Categories;
using FluentValidation;

namespace Education.Application.Categories.DeleteCategory;

internal sealed class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category ID must not be empty.")
            .GreaterThan(0)
            .WithMessage("Category ID must be greater than 0.")
            .MustAsync(DoesCategoryExist)
            .WithMessage("Category with the specified ID does not exist.");
    }

    private async Task<bool> DoesCategoryExist(int categoryId, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId, cancellationToken);
        return category is not null;
    }
}
