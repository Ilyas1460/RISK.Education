using Education.Persistence.Abstractions;
using MediatR;

namespace Education.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
