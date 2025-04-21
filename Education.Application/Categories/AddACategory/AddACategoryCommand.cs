using Education.Application.Abstractions.Messaging;

namespace Education.Application.Categories.AddACategory;

public record AddACategoryCommand(string Title, string Description) : ICommand;