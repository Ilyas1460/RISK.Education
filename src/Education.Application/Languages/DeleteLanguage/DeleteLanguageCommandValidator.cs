using Education.Exceptions.Exceptions;
using Education.Persistence.Languages;
using FluentValidation;

namespace Education.Application.Languages.DeleteLanguage;

internal sealed class DeleteLanguageCommandValidator : AbstractValidator<DeleteLanguageCommand>
{
    private readonly ILanguageRepository _languageRepository;

    public DeleteLanguageCommandValidator(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;

        RuleFor(x => x.LanguageId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Language ID must not be empty.")
            .MustAsync(DoesLanguageExist);
    }

    private async Task<bool> DoesLanguageExist(int languageId, CancellationToken cancellationToken)
    {
        var language = await _languageRepository.GetByIdAsync(languageId, cancellationToken);

        if (language is null)
        {
            throw new NotFoundException($"Language with ID {languageId} not found.");
        }

        return true;
    }
}
