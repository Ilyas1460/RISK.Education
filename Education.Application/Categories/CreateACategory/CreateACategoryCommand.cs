using Education.Application.Abstractions.Messaging;

namespace Education.Application.Categories.CreateACategory;

public record CreateACategoryCommand(string Title, string Description) : ICommand;
