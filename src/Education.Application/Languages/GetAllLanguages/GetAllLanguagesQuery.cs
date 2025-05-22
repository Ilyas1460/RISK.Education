using MediatR;

namespace Education.Application.Languages.GetAllLanguages;

public record GetAllLanguagesQuery : IRequest<GetAllLanguagesQueryResponse>;
