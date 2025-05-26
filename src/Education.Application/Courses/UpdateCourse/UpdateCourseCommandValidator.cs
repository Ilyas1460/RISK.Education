using Education.Exceptions.Exceptions;
using Education.Persistence.Categories;
using Education.Persistence.Courses;
using Education.Persistence.Languages;
using FluentValidation;

namespace Education.Application.Courses.UpdateCourse;

internal sealed class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCourseCommandValidator(ICourseRepository courseRepository, ILanguageRepository languageRepository,
        ICategoryRepository categoryRepository)
    {
        _languageRepository = languageRepository;
        _categoryRepository = categoryRepository;
        _courseRepository = courseRepository;

        RuleFor(x => x.CourseId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Course ID must not be empty.")
            .MustAsync(DoesCourseExist);

        RuleFor(x => x)
            .MustAsync(IsUniqueNameCategoryLanguageGroup);

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Course name is required.");

        RuleFor(x => x.ShortDescription)
            .MaximumLength(200)
            .WithMessage("Short description must not exceed 200 characters.");

        RuleFor(x => x.Slug)
            .MustAsync((command, slug, cancellationToken) => IsSlugUnique(command.CourseId, slug, cancellationToken))
            .When(x => !string.IsNullOrEmpty(x.Slug));

        RuleFor(x => x.QuestionAnswerCount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("QuestionAnswerCount must be greater than or equal to 0.");

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

    private async Task<bool> DoesCourseExist(int courseId, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(courseId, cancellationToken);

        if (course is null)
        {
            throw new NotFoundException($"Course with ID {courseId} not found.");
        }

        return true;
    }

    private async Task<bool> IsUniqueNameCategoryLanguageGroup(UpdateCourseCommand command,
        CancellationToken cancellationToken)
    {
        var doesExistByNameAndCategoryIdAndLanguageId =
            await _courseRepository.ExistsByNameCategoryAndLanguageExcludingIdAsync(command.CourseId,
                command.Name,
                command.CategoryId,
                command.LanguageId,
                cancellationToken);

        if (doesExistByNameAndCategoryIdAndLanguageId)
        {
            throw new ConflictException($"Course with name '{command.Name}' already exists in the same category and language.");
        }

        return true;
    }

    private async Task<bool> IsSlugUnique(int courseId, string? slug, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetBySlugAsync(slug!, cancellationToken);

        if (course is not null && course.Id != courseId)
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
