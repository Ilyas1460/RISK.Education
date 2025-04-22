using FluentValidation;

namespace Education.Application.Categories.DeleteCategory;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator() =>
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category ID must not be empty.")
            .GreaterThan(0)
            .WithMessage("Category ID must be greater than 0.");
}
