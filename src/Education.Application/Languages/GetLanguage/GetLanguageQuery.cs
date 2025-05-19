using MediatR;

namespace Education.Application.Languages.GetLanguage;

public record GetLanguageQuery(int LanguageId) : IRequest<GetLanguageQueryResponse>;
