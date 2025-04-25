using Education.Persistence.Abstractions;
using Education.Persistence.Categories;
using MediatR;

namespace Education.Application.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            throw new InvalidOperationException($"Category with ID {request.CategoryId} not found.");
        }

        category.UpdateCategory(request.Title, request.Description);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateCategoryCommandResponse(category.Id);
    }
}
