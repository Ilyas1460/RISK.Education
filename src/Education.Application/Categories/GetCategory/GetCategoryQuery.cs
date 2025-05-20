using MediatR;

namespace Education.Application.Categories.GetCategory;

public sealed record GetCategoryQuery(int CategoryId) : IRequest<GetCategoryQueryResponse>;
