namespace Education.Application.Abstractions.Exceptions;

// TODO: Use ProblemDetails instead
public record ValidationError(string PropertyName, string ErrorMessage);
