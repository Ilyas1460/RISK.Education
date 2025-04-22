using Education.Persistence.Abstractions;
using Education.Persistence.Categories;
using MediatR;

namespace Education.Application.Categories.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            throw new InvalidOperationException($"Category with ID {request.CategoryId} not found.");
        }

        category.UpdateTitle(request.Title);
        category.UpdateDescription(request.Description);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
