using Education.Application.Abstractions.Messaging;

namespace Education.Application.Categories.DeleteCategory;

public sealed record DeleteCategoryCommand(int CategoryId) : ICommand<DeleteCategoryCommandResponse>;
