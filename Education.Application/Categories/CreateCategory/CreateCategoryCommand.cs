using Education.Application.Abstractions.Messaging;

namespace Education.Application.Categories.CreateCategory;

public record CreateCategoryCommand(string Title, string Description) : ICommand;
