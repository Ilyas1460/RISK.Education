using Education.Application.Abstractions.Messaging;
using Education.Persistence.Categories;

namespace Education.Application.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        category!.UpdateCategory(request.Title, request.Description);

        return new UpdateCategoryCommandResponse(0);
    }
}
