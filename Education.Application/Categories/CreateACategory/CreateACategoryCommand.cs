using Education.Application.Abstractions.Messaging;

namespace Education.Application.Categories.AddACategory;

public record CreateACategoryCommand(string Title, string Description) : ICommand;