using Education.Application.Categories.DeleteACategory;
using FluentValidation;

namespace Education.Application.Categories.DeleteACategory;

public class DeleteACategoryCommandValidator : AbstractValidator<DeleteACategoryCommand> {
    public DeleteACategoryCommandValidator() {
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category ID must not be empty.")
            .GreaterThan(0)
            .WithMessage("Category ID must be greater than 0.");
    }
}