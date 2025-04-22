using FluentValidation;

namespace Education.Application.Categories.GetACategory;

public class GetACategoryQueryValidator : AbstractValidator<GetACategoryQuery>
{
    public GetACategoryQueryValidator() =>
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("CategoryId is required.")
            .GreaterThan(0)
            .WithMessage("CategoryId must be greater than 0.");
}
