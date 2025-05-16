using MediatR;

namespace Education.Application.Categories.GetAllCategories;

public sealed record GetAllCategoriesQuery : IRequest<GetAllCategoriesQueryResponse>;
