using FluentValidation;

namespace Education.Application.Categories.GetCategory;

internal sealed class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
{
    public GetCategoryQueryValidator() =>
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("CategoryId is required.")
            .GreaterThan(0)
            .WithMessage("CategoryId must be greater than 0.");
}
