using MediatR;

namespace Education.Application.Languages.GetLanguage;

public sealed record GetLanguageQuery(int LanguageId) : IRequest<GetLanguageQueryResponse>;
