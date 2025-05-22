using MediatR;

namespace Education.Application.Languages.DeleteLanguage;

public record DeleteLanguageCommand(int LanguageId) : IRequest<DeleteLanguageCommandResponse>;
