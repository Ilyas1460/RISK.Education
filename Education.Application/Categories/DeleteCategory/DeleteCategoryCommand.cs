using Education.Application.Abstractions.Messaging;

namespace Education.Application.Categories.DeleteCategory;

public record DeleteCategoryCommand(int CategoryId) : ICommand;
