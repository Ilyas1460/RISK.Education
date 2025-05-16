using MediatR;

namespace Education.Application.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand : IRequest<UpdateCategoryCommandResponse>
{
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
};
