using Education.Persistence.Abstractions;
using Education.Persistence.Categories;
using MediatR;

namespace Education.Application.Categories.DeleteCategory;

internal sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        _categoryRepository.Delete(category!, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteCategoryCommandResponse(request.CategoryId);
    }
}
