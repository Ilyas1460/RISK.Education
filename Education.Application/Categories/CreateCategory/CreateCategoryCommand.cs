using MediatR;

namespace Education.Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Title, string Description) : IRequest;
