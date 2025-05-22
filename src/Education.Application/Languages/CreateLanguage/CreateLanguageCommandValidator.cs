using Education.Application.Abstractions.Localization;
using Education.Exceptions.Exceptions;
using Education.Persistence.Languages;
using FluentValidation;

namespace Education.Application.Languages.CreateLanguage;

public class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommand>
{
    private readonly ILanguageRepository _languageRepository;
    private readonly ILanguageCodeProvider _languageCodeProvider;

    public CreateLanguageCommandValidator(ILanguageRepository languageRepository, ILanguageCodeProvider languageCodeProvider)
    {
        _languageRepository = languageRepository;
        _languageCodeProvider = languageCodeProvider;

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Code is required.")
            .Length(2)
            .WithMessage("Code must be exactly 2 characters long.")
            .Must(code => languageCodeProvider.GetValidLanguageCodes().Contains(code.ToLower()))
            .WithMessage("Code must be a valid ISO 639-1 language code.")
            .MustAsync(IsUniqueCode);
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
