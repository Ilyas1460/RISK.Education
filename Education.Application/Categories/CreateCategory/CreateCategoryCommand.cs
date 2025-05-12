using Education.Application.Abstractions.Messaging;

namespace Education.Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Title, string Description) : ICommand<CreateCategoryCommandResponse>;
