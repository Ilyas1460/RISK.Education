using Education.Application.Abstractions.Messaging;

namespace Education.Application.Categories.GetCategory;

public sealed record GetCategoryQuery(int CategoryId) : IQuery<GetCategoryQueryResponse>;
