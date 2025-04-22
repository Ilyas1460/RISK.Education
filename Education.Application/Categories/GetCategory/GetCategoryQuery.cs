using Education.Persistence.Categories;
using MediatR;

namespace Education.Application.Categories.GetCategory;

public record GetCategoryQuery(int CategoryId) : IRequest<Category>;
