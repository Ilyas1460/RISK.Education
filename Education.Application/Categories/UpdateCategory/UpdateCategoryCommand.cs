using Education.Application.Abstractions.Messaging;

namespace Education.Application.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand : ICommand<UpdateCategoryCommandResponse>
{
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
};
