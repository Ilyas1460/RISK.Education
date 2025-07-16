﻿using MediatR;

namespace Education.Application.Languages.CreateLanguage;

public sealed record CreateLanguageCommand(string Code) : IRequest<CreateLanguageCommandResponse>;
