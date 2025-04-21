using Education.Application.Abstractions.Messaging;
using Education.Persistence.Categories;

namespace Education.Application.Categories.GetACategory;

public record GetACategoryQuery(int CategoryId) : IQuery<Category>; 