using Education.Application.Abstractions.Messaging;
using Education.Persistence.Categories;

namespace Education.Application.Categories.GetCategory;

public record GetCategoryQuery(int CategoryId) : IQuery<Category>;
