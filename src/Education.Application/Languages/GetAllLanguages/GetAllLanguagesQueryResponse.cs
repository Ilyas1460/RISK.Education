using Education.Application.Languages.GetLanguage;

namespace Education.Application.Languages.GetAllLanguages;

public record GetAllLanguagesQueryResponse(IReadOnlyList<GetLanguageQueryResponse> Languages);
