using MediatR;

namespace Education.Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name) : IRequest<CreateCategoryCommandResponse>;
