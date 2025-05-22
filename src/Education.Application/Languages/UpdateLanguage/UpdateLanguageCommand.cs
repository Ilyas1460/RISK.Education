using MediatR;

namespace Education.Application.Languages.UpdateLanguage;

public record UpdateLanguageCommand : IRequest<UpdateLanguageCommandResponse>
{
    public int LanguageId { get; set; }
    public string Code { get; set; }
}
