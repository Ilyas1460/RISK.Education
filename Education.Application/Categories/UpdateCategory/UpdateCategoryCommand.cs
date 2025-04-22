using Education.Application.Abstractions.Messaging;

namespace Education.Application.Categories.UpdateCategory;

public record UpdateCategoryCommand(int CategoryId, string NewTitle, string NewDescription) : ICommand;
