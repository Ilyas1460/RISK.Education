using Education.Application.Abstractions.Messaging;
using Education.Persistence.Categories;

namespace Education.Application.Categories.DeleteCategory;

internal sealed class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        _categoryRepository.Delete(category!, cancellationToken);

        return new DeleteCategoryCommandResponse(0);
    }
}
