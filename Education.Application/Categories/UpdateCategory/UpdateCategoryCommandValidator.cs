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
            .MustAsync(DoesCategoryExist)
            .WithMessage("Category with the specified ID does not exist.");

        RuleFor(c => c.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MinimumLength(4)
            .WithMessage("Title must be at least 4 characters long.")
            .MustAsync(IsUniqueTitle)
            .WithMessage("Category with the same title already exists.");

        RuleFor(c => c.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MinimumLength(15)
            .WithMessage("Description must be at least 15 characters long.");
    }

    private async Task<bool> DoesCategoryExist(int id, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken);
        return category is not null;
    }

    private async Task<bool> IsUniqueTitle(string title, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByTitleAsync(title, cancellationToken);
        return category is null;
    }
}
