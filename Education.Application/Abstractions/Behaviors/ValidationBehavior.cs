using Education.Application.Abstractions.Exceptions;
using FluentValidation;
using MediatR;
using ValidationException = Education.Application.Abstractions.Exceptions.ValidationException;

namespace Education.Application.Abstractions.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next(cancellationToken);
        }

        var validationErrors = _validators
            .Select(validator => validator.Validate(request))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure is not null)
            .Select(failure => new ValidationError(
                failure.PropertyName,
                failure.ErrorMessage))
            .Distinct()
            .ToList();

        if (validationErrors.Any())
        {
            throw new ValidationException(validationErrors);
        }

        return await next(cancellationToken);
    }
}
