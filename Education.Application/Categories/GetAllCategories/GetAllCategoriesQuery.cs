using Education.Persistence.Categories;
using MediatR;

namespace Education.Application.Categories.GetAllCategories;

public record GetAllCategoriesQuery : IRequest<IEnumerable<Category>>;
