namespace Education.Application.Abstractions.Localization;

public interface ILanguageCodeProvider
{
    IReadOnlySet<string> GetValidLanguageCodes();
}
