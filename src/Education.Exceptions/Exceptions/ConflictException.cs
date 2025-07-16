﻿namespace Education.Exceptions.Exceptions;

public class ConflictException : BaseException
{
    public ConflictException(string message) : base(message)
    {
    }

    public ConflictException(string message, params object[] parameters) : base(message, parameters)
    {
    }
}
