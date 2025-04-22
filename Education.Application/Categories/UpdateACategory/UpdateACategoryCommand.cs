using Education.Application.Abstractions.Messaging;

namespace Education.Application.Categories.UpdateACategory;

public record UpdateACategoryCommand(int CategoryId, string NewTitle, string NewDescription) : ICommand;
