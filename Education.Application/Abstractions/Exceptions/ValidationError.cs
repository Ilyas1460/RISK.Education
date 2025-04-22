namespace Education.Application.Abstractions.Exceptions;

public record ValidationError(string PropertyName, string ErrorMessage);
