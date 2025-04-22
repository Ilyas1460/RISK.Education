using FluentValidation;

namespace Education.Application.Categories.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MinimumLength(4)
            .WithMessage("Title must be at least 4 characters long.");

        RuleFor(c => c.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MinimumLength(15)
            .WithMessage("Description must be at least 15 characters long.");
    }
}
