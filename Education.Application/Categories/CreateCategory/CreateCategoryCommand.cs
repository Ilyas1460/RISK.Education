using MediatR;

namespace Education.Application.Categories.CreateCategory;

public record CreateCategoryCommand(string Title, string Description) : IRequest;
