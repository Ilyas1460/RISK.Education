using Education.Exceptions.Exceptions;
using Education.Persistence.Languages;
using FluentValidation;

namespace Education.Application.Languages.CreateLanguage;

public class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommand>
{
    private readonly ILanguageRepository _languageRepository;

    public CreateLanguageCommandValidator(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Code is required.")
            .Length(2)
            .WithMessage("Code must be exactly 2 characters long.")
            .Matches("^[A-Z]{2}$")
            .WithMessage("Code must be uppercase letters.")
            .Must(code => LanguageCodes.ValidLanguageCodes.Contains(code.ToLower()))
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
