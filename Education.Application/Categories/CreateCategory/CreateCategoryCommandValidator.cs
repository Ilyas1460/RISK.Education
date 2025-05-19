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

        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MustAsync(IsUniqueTitle);
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
