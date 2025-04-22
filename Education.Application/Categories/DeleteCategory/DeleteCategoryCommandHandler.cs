using Education.Persistence.Abstractions;
using Education.Persistence.Categories;
using MediatR;

namespace Education.Application.Categories.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            throw new InvalidOperationException($"Category with ID {request.CategoryId} not found.");
        }

        _categoryRepository.Delete(category, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
