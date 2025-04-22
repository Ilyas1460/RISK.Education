using MediatR;

namespace Education.Application.Categories.DeleteCategory;

public record DeleteCategoryCommand(int CategoryId) : IRequest;
