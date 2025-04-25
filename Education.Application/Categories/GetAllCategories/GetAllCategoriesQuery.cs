using Education.Persistence.Categories;
using MediatR;

namespace Education.Application.Categories.GetAllCategories;

public sealed record GetAllCategoriesQuery : IRequest<GetAllCategoriesQueryResponse>;
