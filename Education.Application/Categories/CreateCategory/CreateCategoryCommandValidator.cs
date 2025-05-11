using Education.Exceptions.Exceptions;
using Education.Persistence.Categories;
using FluentValidation;

namespace Education.Application.Categories.CreateCategory;

internal sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

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

    private async Task<bool> IsUniqueTitle(string title, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByTitleAsync(title, cancellationToken);

        if (category is not null)
        {
            throw new ConflictException("Category with title {0} already exists.", title);
        }

        return true;
    }
}
