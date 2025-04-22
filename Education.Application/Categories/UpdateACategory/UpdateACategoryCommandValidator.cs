using FluentValidation;

namespace Education.Application.Categories.UpdateACategory;

internal class UpdateACategoryCommandValidator : AbstractValidator<UpdateACategoryCommand>
{
    public UpdateACategoryCommandValidator()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("CategoryId is required.")
            .GreaterThan(0)
            .WithMessage("CategoryId must be greater than 0.");

        RuleFor(c => c.NewTitle)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MinimumLength(4)
            .WithMessage("Title must be at least 4 characters long.");

        RuleFor(c => c.NewDescription)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MinimumLength(15)
            .WithMessage("Description must be at least 15 characters long.");
    }
}
