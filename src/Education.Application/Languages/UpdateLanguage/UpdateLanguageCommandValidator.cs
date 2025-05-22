using Education.Application.Abstractions.Localization;
using Education.Exceptions.Exceptions;
using Education.Persistence.Languages;
using FluentValidation;

namespace Education.Application.Languages.UpdateLanguage;

public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly ILanguageCodeProvider _languageCodeProvider;

    public UpdateLanguageCommandValidator(ILanguageRepository languageRepository, ILanguageCodeProvider languageCodeProvider)
    {
        _languageRepository = languageRepository;
        _languageCodeProvider = languageCodeProvider;

        RuleFor(x => x.LanguageId)
            .NotEmpty()
            .WithMessage("Language ID must not be empty.")
            .MustAsync(DoesLanguageExist);

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Code is required.")
            .Length(2)
            .WithMessage("Code must be exactly 2 characters long.")
            .Must(code => languageCodeProvider.GetValidLanguageCodes().Contains(code.ToLower()))
            .WithMessage("Code must be a valid ISO 639-1 language code.")
            .MustAsync(IsUniqueCode);
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

    private async Task<bool> IsUniqueCode(string code, CancellationToken cancellationToken)
    {
        var language = await _languageRepository.GetByCodeAsync(code, cancellationToken);

        if (language is not null)
        {
            throw new ConflictException($"Language with code '{code}' already exists.");
        }

        return true;
    }
}
