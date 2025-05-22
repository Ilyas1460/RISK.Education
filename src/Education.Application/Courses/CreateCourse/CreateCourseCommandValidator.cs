using Education.Exceptions.Exceptions;
using Education.Persistence.Categories;
using Education.Persistence.Courses;
using Education.Persistence.Languages;
using FluentValidation;

namespace Education.Application.Courses.CreateCourse;

internal sealed class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateCourseCommandValidator(ICourseRepository courseRepository, ILanguageRepository languageRepository,
        ICategoryRepository categoryRepository)
    {
        _languageRepository = languageRepository;
        _categoryRepository = categoryRepository;
        _courseRepository = courseRepository;

        RuleFor(x => x)
            .MustAsync(IsUniqueNameCategoryLanguageGroup);

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Course name is required.");

        RuleFor(x => x.ShortDescription)
            .NotEmpty()
            .WithMessage("Short description is required.")
            .MaximumLength(200)
            .WithMessage("Short description must not exceed 200 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.");

        RuleFor(x => x.IsActive)
            .NotNull()
            .WithMessage("IsActive is required.");

        RuleFor(x => x.Slug)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Slug is required.")
            .MustAsync(IsSlugUnique);

        RuleFor(x => x.QuestionAnswerCount)
            .NotNull()
            .WithMessage("QuestionAnswerCount is required.")
            .GreaterThan(0)
            .WithMessage("QuestionAnswerCount must be greater than 0.");

        RuleFor(x => x.CategoryId)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("CategoryId is required.")
            .MustAsync(DoesCategoryExist);

        RuleFor(x => x.LanguageId)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("LanguageId is required.")
            .MustAsync(DoesLanguageExist);
    }

    private async Task<bool> IsUniqueNameCategoryLanguageGroup(CreateCourseCommand command,
        CancellationToken cancellationToken)
    {
        var doesExistByNameAndCategoryIdAndLanguageId =
            await _courseRepository.ExistsByNameCategoryAndLanguageAsync(command.Name, command.CategoryId,
                command.LanguageId,
                cancellationToken);

        if (doesExistByNameAndCategoryIdAndLanguageId)
        {
            throw new ConflictException($"Course with name '{command.Name}' already exists in the same category and language.");
        }

        return true;
    }

    private async Task<bool> IsSlugUnique(string? slug, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetBySlugAsync(slug, cancellationToken);

        if (course is not null)
        {
            throw new ConflictException($"Course with slug '{slug}' already exists.");
        }

        return true;
    }

    private async Task<bool> DoesCategoryExist(int categoryId, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId, cancellationToken);

        if (category is null)
        {
            throw new NotFoundException($"Category with ID '{categoryId}' does not exist.");
        }

        return true;
    }

    private async Task<bool> DoesLanguageExist(int languageId, CancellationToken cancellationToken)
    {
        var language = await _languageRepository.GetByIdAsync(languageId, cancellationToken);

        if (language is null)
        {
            throw new NotFoundException($"Language with ID '{languageId}' does not exist.");
        }

        return true;
    }
}
