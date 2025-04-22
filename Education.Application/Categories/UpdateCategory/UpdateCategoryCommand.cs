using MediatR;

namespace Education.Application.Categories.UpdateCategory;

public record UpdateCategoryCommand : IRequest
{
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
};
