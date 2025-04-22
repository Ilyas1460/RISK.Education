using Education.Application.Abstractions.Messaging;
using Education.Persistence.Categories;

namespace Education.Application.Categories.GetAllCategories;

public record GetAllCategoriesQuery : IQuery<IEnumerable<Category>>;
