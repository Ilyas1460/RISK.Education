using Education.Application.Abstractions.Messaging;

namespace Education.Application.Categories.DeleteACategory;

public record DeleteACategoryCommand(int CategoryId) : ICommand;