using MediatR;

namespace Education.Application.Categories.DeleteCategory;

public sealed record DeleteCategoryCommand(int CategoryId) : IRequest;
