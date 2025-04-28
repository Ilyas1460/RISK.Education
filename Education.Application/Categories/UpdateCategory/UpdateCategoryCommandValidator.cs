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

        RuleFor(c => c.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MinimumLength(4)
            .WithMessage("Title must be at least 4 characters long.")
            .MustAsync(IsUniqueTitle);

        RuleFor(c => c.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MinimumLength(15)
            .WithMessage("Description must be at least 15 characters long.");
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

    private async Task<bool> IsUniqueTitle(string title, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByTitleAsync(title, cancellationToken);

        if (category is not null)
        {
            throw new ConflictException($"Category with title '{title}' already exists.");
        }

        return true;
    }
}
