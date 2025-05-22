using MediatR;

namespace Education.Application.Languages.CreateLanguage;

public record CreateLanguageCommand(string Code) : IRequest<CreateLanguageCommandResponse>;
