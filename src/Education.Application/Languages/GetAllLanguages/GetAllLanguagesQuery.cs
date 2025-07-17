using MediatR;

namespace Education.Application.Languages.GetAllLanguages;

public sealed record GetAllLanguagesQuery : IRequest<GetAllLanguagesQueryResponse>;
