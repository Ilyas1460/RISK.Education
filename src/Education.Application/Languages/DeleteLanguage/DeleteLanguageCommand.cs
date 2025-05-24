using MediatR;

namespace Education.Application.Languages.DeleteLanguage;

public sealed record DeleteLanguageCommand(int LanguageId) : IRequest<DeleteLanguageCommandResponse>;
