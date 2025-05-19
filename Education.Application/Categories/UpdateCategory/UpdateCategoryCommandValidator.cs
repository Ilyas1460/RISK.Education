using Education.Exceptions.Exceptions;
using Education.Persistence.Categories;
using FluentValidation;

namespace Education.Application.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(c => c.CategoryId)
            .NotEmpty()
            .WithMessage("CategoryId is required.")
            .GreaterThan(0)
            .WithMessage("CategoryId must be greater than 0.")
            .MustAsync(DoesCategoryExist);

        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MustAsync(IsUniqueTitle);
    }

    private async Task<bool> DoesCategoryExist(int categoryId, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId, cancellationToken);

        if (category is null)
        {
            throw new NotFoundException("Category with ID {0} not found.", categoryId);
        }

        return true;
    }

    private async Task<bool> IsUniqueTitle(string title, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByNameAsync(title, cancellationToken);

        if (category is not null)
        {
            throw new ConflictException("Category with title {0} already exists.", title);
        }

        return true;
    }
}
